namespace Deform
{
	public interface IData
	{
		void ResetData(DataFlags dataFlags);

		void ApplyData(DataFlags dataFlags);

		void Dispose();
	}
}
