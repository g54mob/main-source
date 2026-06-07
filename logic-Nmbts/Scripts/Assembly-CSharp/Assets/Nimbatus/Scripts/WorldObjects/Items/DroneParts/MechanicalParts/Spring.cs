using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts
{
	public class Spring : DronePart
	{
		[BoolSetting("DronePartSettings/LinearSpring", UndoManager.EStoreReason.SpringLock)]
		public bool Linear;

		public int MinStrength;

		public int MaxStrength;

		public int SliderSteps = 19;

		[IntSetting("DronePartSettings/Strength", "MinStrength", "MaxStrength", "SliderSteps", UndoManager.EStoreReason.SpringStrength)]
		public int Strength;

		public float SegmentWidth;

		public float SegmentHeight;

		public float LineWidth;

		public Material SpringMaterial;

		private int _segmentCount;

		protected override void Validate()
		{
			base.Validate();
			Strength = Mathf.Clamp(Strength, MinStrength, MaxStrength);
		}

		protected override void Awake()
		{
			CustomLineRenderer = true;
			base.Awake();
			LineRenderer = base.gameObject.AddMissingComponent<LineRenderer>();
		}

		protected override void Start()
		{
			base.Start();
			if (ParentDronePart != null || DronePartRangeManager.SelectedItem != null)
			{
				Vector3 vector = ((ParentDronePart != null) ? ParentDronePart.GetChildAttachPosition(base.transform) : DronePartRangeManager.SelectedItem.transform.position);
				vector = new Vector3(vector.x, vector.y, 1f);
				Vector3 a = new Vector3(base.transform.position.x, base.transform.position.y, 1f);
				_segmentCount = Mathf.Max(2, (int)(Vector3.Distance(a, vector) / SegmentHeight));
			}
			LineRenderer.positionCount = _segmentCount + 1;
			LineRenderer.material = SpringMaterial;
			ConfigurableJoint configurableJoint = Joint as ConfigurableJoint;
			if (!(configurableJoint == null))
			{
				configurableJoint.yMotion = ConfigurableJointMotion.Limited;
				configurableJoint.xMotion = ((!Linear) ? ConfigurableJointMotion.Limited : ConfigurableJointMotion.Locked);
				configurableJoint.linearLimit = new SoftJointLimit
				{
					limit = 0.05f,
					bounciness = 1f
				};
				configurableJoint.linearLimitSpring = new SoftJointLimitSpring
				{
					spring = Strength,
					damper = 1f
				};
				if (Linear && ParentDronePart != null)
				{
					float angle = 0f - Vector2.SignedAngle(base.transform.position - ParentDronePart.transform.position, -base.transform.up);
					configurableJoint.axis = TransformHelper.RotateVector(Vector3.right, angle);
					configurableJoint.secondaryAxis = TransformHelper.RotateVector(Vector3.up, angle);
				}
			}
		}

		public override void Update()
		{
			base.Update();
			if (LineRenderer != null && (ParentDronePart != null || DronePartRangeManager.SelectedItem != null))
			{
				LineRenderer.enabled = true;
				Vector3 vector = ((ParentDronePart != null) ? ParentDronePart.GetChildAttachPosition(base.transform) : DronePartRangeManager.SelectedItem.transform.position);
				vector = new Vector3(vector.x, vector.y, 1f);
				Vector3 vector2 = new Vector3(base.transform.position.x, base.transform.position.y, 1f);
				if (RuntimeGlobals.RunningMode == ERunningMode.DroneCustomization)
				{
					int num = Mathf.Max(2, (int)(Vector3.Distance(vector2, vector) / SegmentHeight));
					if (_segmentCount != num)
					{
						_segmentCount = num;
						LineRenderer.positionCount = _segmentCount + 1;
					}
				}
				LineRenderer.startWidth = LineWidth;
				LineRenderer.endWidth = LineWidth;
				Vector3 vector3 = vector2 - vector;
				Vector3 vector4 = Vector3.Cross(vector3, Vector3.forward);
				vector4.Normalize();
				for (int i = 0; i <= _segmentCount; i++)
				{
					float num2 = ((i % 2 != 0) ? 1f : (-1f));
					Vector3 vector5 = vector + vector3 / _segmentCount * i + vector4 * SegmentWidth * num2;
					vector5 = new Vector3(vector5.x, vector5.y, 1f);
					LineRenderer.SetPosition(i, vector5);
				}
			}
			else if (LineRenderer != null)
			{
				LineRenderer.enabled = false;
			}
		}

		public override string GetDetailedTooltip()
		{
			string text = base.GetDetailedTooltip() + LabelHelper.NewLine;
			return text + LabelHelper.White + LocalizationManager.GetTermTranslation("DronePartSettings/Strength") + ": " + LabelHelper.Orange + Strength;
		}

		public override NimbatusItemData CreateData()
		{
			return new SpringData();
		}

		public override void FillUpData(ref NimbatusItemData data)
		{
			base.FillUpData(ref data);
			SpringData springData;
			if ((springData = data as SpringData) != null)
			{
				springData.Strength = Strength;
				springData.Linear = Linear;
			}
		}

		public override void Load(NimbatusItemData data)
		{
			base.Load(data);
			SpringData springData;
			if ((springData = data as SpringData) != null)
			{
				Strength = springData.Strength;
				Linear = springData.Linear;
			}
		}
	}
}
