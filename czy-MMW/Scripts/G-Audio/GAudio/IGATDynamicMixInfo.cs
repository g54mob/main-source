namespace GAudio
{
	public interface IGATDynamicMixInfo
	{
		double Pitch { get; }

		double StaticPitch { get; }

		bool HasStaticPitch { get; }

		float Pan { get; }

		float StaticPan { get; }

		bool HasStaticPan { get; }

		float Gain { get; }

		float StaticGain { get; }

		bool HasStaticGain { get; }

		void Update(double deltaDspTime);

		void SetStaticPitch(double pitch);

		void ClearStaticPitch();

		void SetStaticPan(float pan);

		void ClearStaticPan();

		void SetStaticGain(float gain);

		void ClearStaticGain();

		void OnGameTick();
	}
}
