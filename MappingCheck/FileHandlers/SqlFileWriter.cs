using MappingCheck.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MappingCheck.FileHandlers
{
	public static class SqlFileWriter
	{
		public static void WriteToFile(string fullFileName, List<OutputRow> data)
		{
			var text = new List<string> { OutputRow.Header };
			text.AddRange(data.Select(row => row.ToString()));

			File.WriteAllLines(fullFileName, text);
		}
	}
}
