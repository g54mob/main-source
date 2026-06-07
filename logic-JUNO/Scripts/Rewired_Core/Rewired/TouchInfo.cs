using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool TFKNZzmVDpSoTGbbXvUkLGDXOdjG;

		private int NPpeOpgpTCUZasNhzREMlJjQhGqDb;

		private Vector2 FptDjzNFNcIDjDDyLyXAQGqurYoB;

		private Vector2 dMtXktZQsjoxZSKrEWUUXWDGRyoj;

		private Vector2 WlkuyKNrhaiftaHIOMPNGWyJNfq;

		private Vector2 xsJeuqwGDpjBdGarkNpHhkMFYHKYb;

		private float uWwaMmzWEmQAcoeRTBdQUFHQITqX;

		private int fFHezAaGvTnyxBXkioIoIbMkTfRAb;

		public bool isValid
		{
			get
			{
				return TFKNZzmVDpSoTGbbXvUkLGDXOdjG;
			}
			internal set
			{
				TFKNZzmVDpSoTGbbXvUkLGDXOdjG = value;
			}
		}

		public int touchId
		{
			get
			{
				return NPpeOpgpTCUZasNhzREMlJjQhGqDb;
			}
			internal set
			{
				NPpeOpgpTCUZasNhzREMlJjQhGqDb = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return FptDjzNFNcIDjDDyLyXAQGqurYoB;
			}
			internal set
			{
				FptDjzNFNcIDjDDyLyXAQGqurYoB = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return dMtXktZQsjoxZSKrEWUUXWDGRyoj;
			}
			internal set
			{
				dMtXktZQsjoxZSKrEWUUXWDGRyoj = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return WlkuyKNrhaiftaHIOMPNGWyJNfq;
			}
			internal set
			{
				WlkuyKNrhaiftaHIOMPNGWyJNfq = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return xsJeuqwGDpjBdGarkNpHhkMFYHKYb;
			}
			internal set
			{
				xsJeuqwGDpjBdGarkNpHhkMFYHKYb = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return uWwaMmzWEmQAcoeRTBdQUFHQITqX;
			}
			internal set
			{
				uWwaMmzWEmQAcoeRTBdQUFHQITqX = value;
			}
		}

		public int tapCount
		{
			get
			{
				return fFHezAaGvTnyxBXkioIoIbMkTfRAb;
			}
			internal set
			{
				fFHezAaGvTnyxBXkioIoIbMkTfRAb = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			TFKNZzmVDpSoTGbbXvUkLGDXOdjG = false
		};

		internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
		{
			TFKNZzmVDpSoTGbbXvUkLGDXOdjG = P_0;
			NPpeOpgpTCUZasNhzREMlJjQhGqDb = P_1;
			FptDjzNFNcIDjDDyLyXAQGqurYoB = P_2;
			dMtXktZQsjoxZSKrEWUUXWDGRyoj = P_3;
			WlkuyKNrhaiftaHIOMPNGWyJNfq = P_4;
			xsJeuqwGDpjBdGarkNpHhkMFYHKYb = P_5;
			uWwaMmzWEmQAcoeRTBdQUFHQITqX = P_6;
			fFHezAaGvTnyxBXkioIoIbMkTfRAb = P_7;
		}
	}
}
