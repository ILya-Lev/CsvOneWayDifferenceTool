using MappingCheck.FileHandlers;
using MappingCheck.Model;
using MoreLinq;
using System;
using System.Diagnostics;
using System.Linq;

namespace MappingCheck
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var mdLoader = new CsvFileLoader<MasterDataRow>(null,
															@"resources\masterData_priority.csv");
				var storageLoader = new CsvFileLoader<ProdMappingRow>(null,
															@"resources\storage_priority.csv");
				var masterData = mdLoader.ReadFile();
				var storageData = storageLoader.ReadFile()
										 .DistinctBy(row => row.Key)
										 .ToDictionary(row => row.Key);

				var outputData = masterData.Where(row => !storageData.ContainsKey(row.Key))
											.Select(row => new OutputRow(row)).ToList();

				SqlFileWriter.WriteToFile(@"resources\result.sql", outputData);
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);
				Debug.Print(exc.Message);
			}
		}
	}
}
