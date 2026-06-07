using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool jTKQutBMGFjJXeKoLKVbSPcEzifU;

		private int FjZArvRhMWJxiErEzWEnFoyJBBV;

		private Vector2 vzObXxgRkNvHcDAGenfBtvlXCjRl;

		private Vector2 NXquFWaZCCpGIfrVwOEebosYYPb;

		private Vector2 XatBHOKxGRAGCRrAxTGkIgGbtadH;

		private Vector2 BCKKQxBRDSINdWGsLjCeTxLVYqj;

		private float PIIoQFrWEqFjNpZBsfmKBEAMBOiF;

		private int FHyDZRXpcMVveIAWOtnpnCoMejc;

		public bool isValid
		{
			get
			{
				return jTKQutBMGFjJXeKoLKVbSPcEzifU;
			}
			internal set
			{
				jTKQutBMGFjJXeKoLKVbSPcEzifU = value;
			}
		}

		public int touchId
		{
			get
			{
				return FjZArvRhMWJxiErEzWEnFoyJBBV;
			}
			internal set
			{
				FjZArvRhMWJxiErEzWEnFoyJBBV = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return vzObXxgRkNvHcDAGenfBtvlXCjRl;
			}
			internal set
			{
				vzObXxgRkNvHcDAGenfBtvlXCjRl = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return NXquFWaZCCpGIfrVwOEebosYYPb;
			}
			internal set
			{
				NXquFWaZCCpGIfrVwOEebosYYPb = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return XatBHOKxGRAGCRrAxTGkIgGbtadH;
			}
			internal set
			{
				XatBHOKxGRAGCRrAxTGkIgGbtadH = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return BCKKQxBRDSINdWGsLjCeTxLVYqj;
			}
			internal set
			{
				BCKKQxBRDSINdWGsLjCeTxLVYqj = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return PIIoQFrWEqFjNpZBsfmKBEAMBOiF;
			}
			internal set
			{
				PIIoQFrWEqFjNpZBsfmKBEAMBOiF = value;
			}
		}

		public int tapCount
		{
			get
			{
				return FHyDZRXpcMVveIAWOtnpnCoMejc;
			}
			internal set
			{
				FHyDZRXpcMVveIAWOtnpnCoMejc = value;
			}
		}

		internal static TouchInfo Invalid
		{
			get
			{
				return new TouchInfo
				{
					jTKQutBMGFjJXeKoLKVbSPcEzifU = false
				};
			}
		}

		internal TouchInfo(bool isValid, int touchId, Vector2 touchPos, Vector2 touchPosRaw, Vector2 deltaPos, Vector2 deltaPosRaw, float deltaTime, int tapCount)
		{
			jTKQutBMGFjJXeKoLKVbSPcEzifU = isValid;
			FjZArvRhMWJxiErEzWEnFoyJBBV = touchId;
			vzObXxgRkNvHcDAGenfBtvlXCjRl = touchPos;
			NXquFWaZCCpGIfrVwOEebosYYPb = touchPosRaw;
			XatBHOKxGRAGCRrAxTGkIgGbtadH = deltaPos;
			BCKKQxBRDSINdWGsLjCeTxLVYqj = deltaPosRaw;
			PIIoQFrWEqFjNpZBsfmKBEAMBOiF = deltaTime;
			FHyDZRXpcMVveIAWOtnpnCoMejc = tapCount;
		}
	}
}
