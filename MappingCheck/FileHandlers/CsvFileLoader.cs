using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;

namespace MappingCheck.FileHandlers
{
	public class CsvFileLoader<T>
	{
		private readonly CsvClassMap<T> _map;
		private readonly string _fullFileName;

		public CsvFileLoader(CsvClassMap<T> map, string fullFileName)
		{
			_fullFileName = fullFileName;
			if (!File.Exists(_fullFileName))
				throw new ArgumentException($@"File ""{_fullFileName}"" doesn't exist!");

			_map = map ?? new DefaultCsvClassMap<T>();
			_map.AutoMap(true);
		}

		public List<T> ReadFile()
		{
			var reader = new CsvReader(File.OpenText(_fullFileName));

			reader.Configuration.TrimFields = true;
			reader.Configuration.RegisterClassMap(_map);

			var result = new List<T>();
			while (reader.Read())
				result.Add(reader.GetRecord<T>());

			return result;
		}
	}
}
