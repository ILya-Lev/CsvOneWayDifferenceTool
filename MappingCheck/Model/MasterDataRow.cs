using System;
using System.Diagnostics;

namespace MappingCheck.Model
{
	[DebuggerDisplay("{Key}")]
	public class MasterDataRow
	{
		public string AccountCode { get; set; }
		public string PriorityCode { get; set; }
		public string PriorityName { get; set; }
		public string Rank { get; set; }
		public string Active { get; set; }

		private Tuple<string, string> _key;
		public Tuple<string, string> Key
			=> _key ?? (_key = new Tuple<string, string>(AccountCode, PriorityCode));
	}
}
