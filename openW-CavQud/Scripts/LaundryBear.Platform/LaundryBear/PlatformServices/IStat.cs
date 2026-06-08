namespace LaundryBear.PlatformServices
{
	public interface IStat
	{
		string StatID { get; }

		float GetProgressFloat(string name, OnStatFloatValueGet callback);

		int GetProgressInt(string name, OnStatIntValueGet callback);

		void SetStat(int value, OnStatSet callback);

		void SetStat(float value, OnStatSet callback);

		void AddStat(int increment, OnStatSet callback);

		void AddStat(float increment, OnStatSet callback);
	}
}
