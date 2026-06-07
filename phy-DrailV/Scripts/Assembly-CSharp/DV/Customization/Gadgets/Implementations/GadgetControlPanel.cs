using System;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetControlPanel : ExternallySwitchableGadget
	{
		private const string TILT_SAVE_KEY = "tilt";

		[NonSerialized]
		public float tilt;

		[SerializeField]
		private int tiltKnobRate = 16;

		public int TiltKnobRate => tiltKnobRate;

		public bool IsReversed { get; private set; }

		public bool IsExposedToOutside { get; private set; }

		protected override void OnAfterLinked()
		{
			base.OnAfterLinked();
			IsReversed = Vector3.Dot(base.transform.right, base.Custom.transform.right) < 0f;
			IsExposedToOutside = true;
			if (base.IsOnTrainCar)
			{
				CameraTrigger componentInChildren = base.Custom.GetComponentInChildren<CameraTrigger>();
				if (componentInChildren != null && componentInChildren.IsPointInside(base.transform.position))
				{
					IsExposedToOutside = false;
				}
			}
		}

		protected override void OnAfterUnlinked()
		{
			base.OnAfterUnlinked();
			tilt = 0f;
		}

		public override void SaveDataRequested(JObject dst)
		{
			dst.SetFloat("tilt", tilt);
			base.SaveDataRequested(dst);
		}

		public override void SaveDataLoaded(JObject src)
		{
			base.SaveDataLoaded(src);
			tilt = src.GetFloat("tilt") ?? 0f;
		}
	}
}
