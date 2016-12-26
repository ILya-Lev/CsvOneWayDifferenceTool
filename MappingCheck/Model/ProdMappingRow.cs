using System;
using System.Diagnostics;

namespace MappingCheck.Model
{
	[DebuggerDisplay("{Key}")]
	public class ProdMappingRow
	{
		public string MappingId { get; set; }
		public string MappingType { get; set; }
		public string AccountCode { get; set; }
		public string ObjectCode { get; set; }
		public string ExternalId { get; set; }

		private Tuple<string, string> _key;
		public Tuple<string, string> Key
			=> _key ?? (_key = new Tuple<string, string>(AccountCode, ObjectCode));
	}
}
