namespace Polarith.AI.Criteria
{
	public interface IBehaviour
	{
		bool Enabled { get; set; }

		int Order { get; set; }

		void Behave();
	}
}
