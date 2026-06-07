using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal struct TouchInfo
	{
		private bool AsIGpabQMBfkogwrlxBdKkoAAfgN;

		private int aRBegchRCEOKJqCHXGAzsOqHBYW;

		private Vector2 GmEuEcbKsJfeLBoHQQjFTSrPpiUW;

		private Vector2 ilgeAVHGMMXblOHSKwYsGYuYwGy;

		private Vector2 cJdhILJTORBhxGPLHPYuDBWidpjo;

		private Vector2 cCILNLjJOWfEcmBNhrDQaepZdHj;

		private float gwOePCLaIeNCeTjMYliEsqYKBHxD;

		private int sEsNACfHmKMuRmtLqNddUYkCtqx;

		public bool isValid
		{
			get
			{
				return AsIGpabQMBfkogwrlxBdKkoAAfgN;
			}
			internal set
			{
				AsIGpabQMBfkogwrlxBdKkoAAfgN = value;
			}
		}

		public int touchId
		{
			get
			{
				return aRBegchRCEOKJqCHXGAzsOqHBYW;
			}
			internal set
			{
				aRBegchRCEOKJqCHXGAzsOqHBYW = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return GmEuEcbKsJfeLBoHQQjFTSrPpiUW;
			}
			internal set
			{
				GmEuEcbKsJfeLBoHQQjFTSrPpiUW = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return ilgeAVHGMMXblOHSKwYsGYuYwGy;
			}
			internal set
			{
				ilgeAVHGMMXblOHSKwYsGYuYwGy = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return cJdhILJTORBhxGPLHPYuDBWidpjo;
			}
			internal set
			{
				cJdhILJTORBhxGPLHPYuDBWidpjo = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return cCILNLjJOWfEcmBNhrDQaepZdHj;
			}
			internal set
			{
				cCILNLjJOWfEcmBNhrDQaepZdHj = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return gwOePCLaIeNCeTjMYliEsqYKBHxD;
			}
			internal set
			{
				gwOePCLaIeNCeTjMYliEsqYKBHxD = value;
			}
		}

		public int tapCount
		{
			get
			{
				return sEsNACfHmKMuRmtLqNddUYkCtqx;
			}
			internal set
			{
				sEsNACfHmKMuRmtLqNddUYkCtqx = value;
			}
		}

		internal static TouchInfo Invalid
		{
			get
			{
				return new TouchInfo
				{
					AsIGpabQMBfkogwrlxBdKkoAAfgN = false
				};
			}
		}

		internal TouchInfo(bool isValid, int touchId, Vector2 touchPos, Vector2 touchPosRaw, Vector2 deltaPos, Vector2 deltaPosRaw, float deltaTime, int tapCount)
		{
			AsIGpabQMBfkogwrlxBdKkoAAfgN = isValid;
			aRBegchRCEOKJqCHXGAzsOqHBYW = touchId;
			GmEuEcbKsJfeLBoHQQjFTSrPpiUW = touchPos;
			ilgeAVHGMMXblOHSKwYsGYuYwGy = touchPosRaw;
			cJdhILJTORBhxGPLHPYuDBWidpjo = deltaPos;
			cCILNLjJOWfEcmBNhrDQaepZdHj = deltaPosRaw;
			gwOePCLaIeNCeTjMYliEsqYKBHxD = deltaTime;
			sEsNACfHmKMuRmtLqNddUYkCtqx = tapCount;
		}
	}
}
