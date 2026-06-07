using UnityEngine;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	[HelpURL("http://www.procamera2d.com/user-guide/extension-pointer-influence/")]
	public class ProCamera2DPointerInfluence : BasePC2D, IPreMover
	{
		public static string ExtensionName;

		public float MaxHorizontalInfluence;

		public float MaxVerticalInfluence;

		public float InfluenceSmoothness;

		private Vector2 _influence;

		private Vector2 _velocity;

		private int _prmOrder;

		public int PrMOrder
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		public override void OnReset()
		{
		}

		public void PreMove(float deltaTime)
		{
		}

		private void ApplyInfluence(float deltaTime)
		{
		}
	}
}
