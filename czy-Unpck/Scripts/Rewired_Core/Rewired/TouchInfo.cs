using UnityEngine;

namespace Rewired
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	[CustomObfuscation(rename = false)]
	internal struct TouchInfo
	{
		private bool ltUCirDrbTngxJGUkcmqmAQBhwLE;

		private int NvTfVnBktUGZWRWiMwxuyfOGvJd;

		private Vector2 fUAdnXeLJExUFwqTdAQKMPOVzxa;

		private Vector2 HjqlDQuDjMelgmPvVzEpOMATDbP;

		private Vector2 ThxnQYnGlDoDsqymQhixZcqyakN;

		private Vector2 XjMZqGPRoEaqbXpemvGXsBPOjEAH;

		private float TRAgWZvvhmNxhgrpLVFLsgyJYdC;

		private int FFehwHTfXUrxOFfajASeEUGLLrC;

		public bool isValid
		{
			get
			{
				return ltUCirDrbTngxJGUkcmqmAQBhwLE;
			}
			internal set
			{
				ltUCirDrbTngxJGUkcmqmAQBhwLE = value;
			}
		}

		public int touchId
		{
			get
			{
				return NvTfVnBktUGZWRWiMwxuyfOGvJd;
			}
			internal set
			{
				NvTfVnBktUGZWRWiMwxuyfOGvJd = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return fUAdnXeLJExUFwqTdAQKMPOVzxa;
			}
			internal set
			{
				fUAdnXeLJExUFwqTdAQKMPOVzxa = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return HjqlDQuDjMelgmPvVzEpOMATDbP;
			}
			internal set
			{
				HjqlDQuDjMelgmPvVzEpOMATDbP = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return ThxnQYnGlDoDsqymQhixZcqyakN;
			}
			internal set
			{
				ThxnQYnGlDoDsqymQhixZcqyakN = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return XjMZqGPRoEaqbXpemvGXsBPOjEAH;
			}
			internal set
			{
				XjMZqGPRoEaqbXpemvGXsBPOjEAH = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return TRAgWZvvhmNxhgrpLVFLsgyJYdC;
			}
			internal set
			{
				TRAgWZvvhmNxhgrpLVFLsgyJYdC = value;
			}
		}

		public int tapCount
		{
			get
			{
				return FFehwHTfXUrxOFfajASeEUGLLrC;
			}
			internal set
			{
				FFehwHTfXUrxOFfajASeEUGLLrC = value;
			}
		}

		internal static TouchInfo Invalid
		{
			get
			{
				TouchInfo result = default(TouchInfo);
				while (true)
				{
					int num = -1146151248;
					while (true)
					{
						switch (num ^ -1146151246)
						{
						case 0:
							break;
						case 2:
							goto IL_0026;
						default:
							return result;
						}
						break;
						IL_0026:
						result.ltUCirDrbTngxJGUkcmqmAQBhwLE = false;
						num = -1146151245;
					}
				}
			}
		}

		internal TouchInfo(bool isValid, int touchId, Vector2 touchPos, Vector2 touchPosRaw, Vector2 deltaPos, Vector2 deltaPosRaw, float deltaTime, int tapCount)
		{
			ltUCirDrbTngxJGUkcmqmAQBhwLE = isValid;
			NvTfVnBktUGZWRWiMwxuyfOGvJd = touchId;
			fUAdnXeLJExUFwqTdAQKMPOVzxa = touchPos;
			HjqlDQuDjMelgmPvVzEpOMATDbP = touchPosRaw;
			ThxnQYnGlDoDsqymQhixZcqyakN = deltaPos;
			XjMZqGPRoEaqbXpemvGXsBPOjEAH = deltaPosRaw;
			TRAgWZvvhmNxhgrpLVFLsgyJYdC = deltaTime;
			FFehwHTfXUrxOFfajASeEUGLLrC = tapCount;
		}
	}
}
