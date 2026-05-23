using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool gbccatagYMiSgCTiijVyaQueeilTB;

		private int mrBbFrhExrZmNYuqAcmSOXbfkhcG;

		private Vector2 glLAmfBNSFKSmmGIsrUJUBePrPIYA;

		private Vector2 KbHXixTnhYlamRAkdudAGIfpClio;

		private Vector2 vxVcNkaAwUmgSNmKzCcNjSqALtfEB;

		private Vector2 GBtdPgiNCYgZWeniPUVBstmpTvMSA;

		private float TQIYFivWFFmCVbgOcNlKXlzblRyl;

		private int KHtEBKSaymgEQOrlLiwoyuxRXfDD;

		public bool isValid
		{
			get
			{
				return gbccatagYMiSgCTiijVyaQueeilTB;
			}
			internal set
			{
				gbccatagYMiSgCTiijVyaQueeilTB = value;
			}
		}

		public int touchId
		{
			get
			{
				return mrBbFrhExrZmNYuqAcmSOXbfkhcG;
			}
			internal set
			{
				mrBbFrhExrZmNYuqAcmSOXbfkhcG = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return glLAmfBNSFKSmmGIsrUJUBePrPIYA;
			}
			internal set
			{
				glLAmfBNSFKSmmGIsrUJUBePrPIYA = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return KbHXixTnhYlamRAkdudAGIfpClio;
			}
			internal set
			{
				KbHXixTnhYlamRAkdudAGIfpClio = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return vxVcNkaAwUmgSNmKzCcNjSqALtfEB;
			}
			internal set
			{
				vxVcNkaAwUmgSNmKzCcNjSqALtfEB = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return GBtdPgiNCYgZWeniPUVBstmpTvMSA;
			}
			internal set
			{
				GBtdPgiNCYgZWeniPUVBstmpTvMSA = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return TQIYFivWFFmCVbgOcNlKXlzblRyl;
			}
			internal set
			{
				TQIYFivWFFmCVbgOcNlKXlzblRyl = value;
			}
		}

		public int tapCount
		{
			get
			{
				return KHtEBKSaymgEQOrlLiwoyuxRXfDD;
			}
			internal set
			{
				KHtEBKSaymgEQOrlLiwoyuxRXfDD = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			gbccatagYMiSgCTiijVyaQueeilTB = false
		};

		internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
		{
			gbccatagYMiSgCTiijVyaQueeilTB = P_0;
			mrBbFrhExrZmNYuqAcmSOXbfkhcG = P_1;
			glLAmfBNSFKSmmGIsrUJUBePrPIYA = P_2;
			KbHXixTnhYlamRAkdudAGIfpClio = P_3;
			vxVcNkaAwUmgSNmKzCcNjSqALtfEB = P_4;
			GBtdPgiNCYgZWeniPUVBstmpTvMSA = P_5;
			TQIYFivWFFmCVbgOcNlKXlzblRyl = P_6;
			KHtEBKSaymgEQOrlLiwoyuxRXfDD = P_7;
		}
	}
}
