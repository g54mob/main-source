using UnityEngine;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal struct TouchInfo
	{
		private bool XPAuDXeKLCGLhJyrYypZKUTWGkccA;

		private int LlgINnvBjPOGyhnuHYvMYgJLwdrA;

		private Vector2 PNdfLFDLLLpNpGlDAMqeELFJrXDXB;

		private Vector2 fpzcdVJAgCwPnkilTIKvGPQHfjlgA;

		private Vector2 ChddmUJOrOLlTGRXDxAsGGJzxzcAb;

		private Vector2 rKNaoWmpTIcUFSOxbdbufQLNChXFA;

		private float aGqugMhGONuVESPVIxNfPyOHEftx;

		private int xVDjsOKroXvZljazxCDqkNxxZSq;

		public bool isValid
		{
			get
			{
				return XPAuDXeKLCGLhJyrYypZKUTWGkccA;
			}
			internal set
			{
				XPAuDXeKLCGLhJyrYypZKUTWGkccA = value;
			}
		}

		public int touchId
		{
			get
			{
				return LlgINnvBjPOGyhnuHYvMYgJLwdrA;
			}
			internal set
			{
				LlgINnvBjPOGyhnuHYvMYgJLwdrA = value;
			}
		}

		public Vector2 touchPos
		{
			get
			{
				return PNdfLFDLLLpNpGlDAMqeELFJrXDXB;
			}
			internal set
			{
				PNdfLFDLLLpNpGlDAMqeELFJrXDXB = value;
			}
		}

		public Vector2 touchPosRaw
		{
			get
			{
				return fpzcdVJAgCwPnkilTIKvGPQHfjlgA;
			}
			internal set
			{
				fpzcdVJAgCwPnkilTIKvGPQHfjlgA = value;
			}
		}

		public Vector2 deltaPos
		{
			get
			{
				return ChddmUJOrOLlTGRXDxAsGGJzxzcAb;
			}
			internal set
			{
				ChddmUJOrOLlTGRXDxAsGGJzxzcAb = value;
			}
		}

		public Vector2 deltaPosRaw
		{
			get
			{
				return rKNaoWmpTIcUFSOxbdbufQLNChXFA;
			}
			internal set
			{
				rKNaoWmpTIcUFSOxbdbufQLNChXFA = value;
			}
		}

		public float deltaTime
		{
			get
			{
				return aGqugMhGONuVESPVIxNfPyOHEftx;
			}
			internal set
			{
				aGqugMhGONuVESPVIxNfPyOHEftx = value;
			}
		}

		public int tapCount
		{
			get
			{
				return xVDjsOKroXvZljazxCDqkNxxZSq;
			}
			internal set
			{
				xVDjsOKroXvZljazxCDqkNxxZSq = value;
			}
		}

		internal static TouchInfo Invalid => new TouchInfo
		{
			XPAuDXeKLCGLhJyrYypZKUTWGkccA = false
		};

		internal TouchInfo(bool P_0, int P_1, Vector2 P_2, Vector2 P_3, Vector2 P_4, Vector2 P_5, float P_6, int P_7)
		{
			XPAuDXeKLCGLhJyrYypZKUTWGkccA = P_0;
			LlgINnvBjPOGyhnuHYvMYgJLwdrA = P_1;
			PNdfLFDLLLpNpGlDAMqeELFJrXDXB = P_2;
			fpzcdVJAgCwPnkilTIKvGPQHfjlgA = P_3;
			ChddmUJOrOLlTGRXDxAsGGJzxzcAb = P_4;
			rKNaoWmpTIcUFSOxbdbufQLNChXFA = P_5;
			aGqugMhGONuVESPVIxNfPyOHEftx = P_6;
			xVDjsOKroXvZljazxCDqkNxxZSq = P_7;
		}
	}
}
