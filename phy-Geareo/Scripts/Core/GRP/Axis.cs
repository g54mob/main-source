using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GRP
{
	public class Axis : WorldPointable
	{
		public static Axis current;

		private bool changed;

		private Hertz hertz;

		private float lastClick;

		public event Action onBegin
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<float> onDistanceX
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<Vector3> onDistance
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onEnd
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action onHover
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void BuildUndo(PartHandle part)
		{
		}

		public void BuildUndo(PartView part)
		{
		}

		public void BuildUndo(Func<Part> part)
		{
		}

		public void HandleDistance(Vector3 v)
		{
		}

		public void HandleBegin()
		{
		}

		public void HandleEnd()
		{
		}

		public override void OnClick(WorldPointerEvent evt)
		{
		}

		public override void OnHover(WorldPointerEvent evt)
		{
		}
	}
}
