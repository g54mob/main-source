namespace GAudio
{
	public class GATDynamicMixInfo : IGATDynamicMixInfo
	{
		private double _staticPitch;

		private bool _hasStaticPitch;

		private float _staticPan;

		private bool _hasStaticPan;

		private float _staticGain;

		private bool _hasStaticGain;

		public virtual double Pitch => 0.0;

		public double StaticPitch => _staticPitch;

		public bool HasStaticPitch => _hasStaticPitch;

		public virtual float Pan => -1f;

		public float StaticPan => _staticPan;

		public bool HasStaticPan => _hasStaticPan;

		public virtual float Gain => -1f;

		public float StaticGain => _staticGain;

		public bool HasStaticGain => _hasStaticGain;

		public virtual void Update(double deltaDspTime)
		{
		}

		public virtual void OnGameTick()
		{
		}

		public void SetStaticPitch(double pitch)
		{
			_staticPitch = pitch;
			_hasStaticPitch = true;
		}

		public void ClearStaticPitch()
		{
			_hasStaticPitch = false;
		}

		public void SetStaticPan(float pan)
		{
			_staticPan = pan;
			_hasStaticPan = true;
		}

		public void ClearStaticPan()
		{
			_hasStaticPan = false;
		}

		public void SetStaticGain(float gain)
		{
			_staticGain = gain;
			_hasStaticGain = true;
		}

		public void ClearStaticGain()
		{
			_hasStaticGain = false;
		}
	}
}
