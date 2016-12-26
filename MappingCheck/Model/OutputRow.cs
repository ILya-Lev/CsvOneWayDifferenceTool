namespace MappingCheck.Model
{
	public class OutputRow
	{
		public string AccountCode { get; set; }
		public string ObjectCode { get; set; }
		public string PriorityName { get; set; }

		public OutputRow(MasterDataRow row)
		{
			AccountCode = row.AccountCode;
			ObjectCode = row.PriorityCode;
			PriorityName = row.PriorityName;
		}

		public static string Header
			=> "INSERT INTO dbo.Mappings(MappingType,AccountCode,ObjectCode,ExternalId)";

		public override string ToString()
			=> $@"VALUES(1, '{AccountCode}', '{ObjectCode}', '') -- {PriorityName}";
	}
}
