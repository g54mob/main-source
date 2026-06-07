namespace UMA
{
	public interface IUMAIndexOptions
	{
		bool ForceKeep { get; set; }

		bool LabelLocalFiles { get; set; }

		bool NoAutoAdd { get; set; }
	}
}
