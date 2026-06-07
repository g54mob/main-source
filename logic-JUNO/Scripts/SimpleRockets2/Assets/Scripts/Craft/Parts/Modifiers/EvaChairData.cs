using System;
using System.Xml.Linq;
using Assets.Scripts.Design;
using ModApi.Common.Events;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("EvaChair")]
	[PartModifierTypeId("EvaChair")]
	public class EvaChairData : PartModifierData<EvaChairScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector4i _armTargets = new Vector4i(-1, -1, -1, -1);

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 51, Label = "Forward Look", Order = 1, Tooltip = "A slider forcing the drood in the chair to look forward.")]
		private float _forwardLook;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector4i _legTargets = new Vector4i(-1, -1, -1, -1);

		[DesignerPropertyLabel(PreserveState = false, NeverSerialize = true, Order = 2)]
		private string _topHeader = "Top";

		[DesignerPropertyLabel(PreserveState = false, NeverSerialize = true, Order = 7)]
		private string _bottomHeader = "Bottom";

		[DesignerPropertyCenterButton(Label = "Left Hand", Order = 3, Tooltip = "The ID of the part to be targeted for the left hand's position and rotation")]
		private bool _leftHandTarget;

		[DesignerPropertyCenterButton(Label = "Right Hand", Order = 4, Tooltip = "The ID of the part to be targeted for the right hand's position and rotation")]
		private bool _rightHandTarget;

		[DesignerPropertyCenterButton(Label = "Left Elbow", Order = 5, Tooltip = "The ID of the part to be targeted for the left elbow's position")]
		private bool _leftHandBend;

		[DesignerPropertyCenterButton(Label = "Right Elbow", Order = 6, Tooltip = "The ID of the part to be targeted for the right elbow's position")]
		private bool _rightHandBend;

		[DesignerPropertyCenterButton(Label = "Left Foot", Order = 8, Tooltip = "The ID of the part to be targeted for the left foot's position and rotation")]
		private bool _leftFootTarget;

		[DesignerPropertyCenterButton(Label = "Right Foot", Order = 9, Tooltip = "The ID of the part to be targeted for the right foot's position and rotation")]
		private bool _rightFootTarget;

		[DesignerPropertyCenterButton(Label = "Left Knee", Order = 10, Tooltip = "The ID of the part to be targeted for the left knee's position")]
		private bool _leftFootBend;

		[DesignerPropertyCenterButton(Label = "Right Knee", Order = 11, Tooltip = "The ID of the part to be targeted for the right knee's position")]
		private bool _rightFootBend;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 10f, 39, Label = "Snap Range", Order = 0, Tooltip = "The distance at which a limb will snap back to the rest position and forget what it was trying to grab.")]
		private float _snapRange = 1f;

		public float ForwardLook => _forwardLook;

		public int LeftHandTarget
		{
			get
			{
				return _armTargets.x;
			}
			set
			{
				_armTargets.x = value;
			}
		}

		public int LeftHandBend
		{
			get
			{
				return _armTargets.y;
			}
			set
			{
				_armTargets.y = value;
			}
		}

		public int RightHandTarget
		{
			get
			{
				return _armTargets.z;
			}
			set
			{
				_armTargets.z = value;
			}
		}

		public int RightHandBend
		{
			get
			{
				return _armTargets.w;
			}
			set
			{
				_armTargets.w = value;
			}
		}

		public int LeftFootTarget
		{
			get
			{
				return _legTargets.x;
			}
			set
			{
				_legTargets.x = value;
			}
		}

		public int LeftFootBend
		{
			get
			{
				return _legTargets.y;
			}
			set
			{
				_legTargets.y = value;
			}
		}

		public int RightFootTarget
		{
			get
			{
				return _legTargets.z;
			}
			set
			{
				_legTargets.z = value;
			}
		}

		public int RightFootBend
		{
			get
			{
				return _legTargets.w;
			}
			set
			{
				_legTargets.w = value;
			}
		}

		public float SnapRange => _snapRange * _snapRange;

		public void RemoveAllTargets()
		{
			LeftHandTarget = -1;
			RightHandTarget = -1;
			LeftHandBend = -1;
			RightHandBend = -1;
			LeftFootTarget = -1;
			RightFootTarget = -1;
			LeftFootBend = -1;
			RightFootBend = -1;
		}

		public override XElement GenerateStateXml(bool optimizeXml = true)
		{
			if (Game.IsInitialized && Game.InFlightScene)
			{
				base.Script?.UpdateTargetIDs();
			}
			return base.GenerateStateXml(optimizeXml);
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnPartStyleChanged(delegate
			{
				InvokeParametersChangedOnSymmetricPartModifiers();
			});
			d.OnValueLabelRequested(() => _forwardLook, (float x) => Units.GetPercentageString(x));
			d.OnValueLabelRequested(() => _snapRange, (float x) => Units.GetDistanceString(x));
			d.OnValueLabelRequested(() => _leftHandTarget, (bool x) => (LeftHandTarget != -1) ? ("Left Hand on Part " + LeftHandTarget) : "Left Hand");
			d.OnValueLabelRequested(() => _rightHandTarget, (bool x) => (RightHandTarget != -1) ? ("Right Hand on Part " + RightHandTarget) : "Right Hand");
			d.OnValueLabelRequested(() => _leftHandBend, (bool x) => (LeftHandBend != -1) ? ("Left Elbow on Part " + LeftHandBend) : "Left Elbow");
			d.OnValueLabelRequested(() => _rightHandBend, (bool x) => (RightHandBend != -1) ? ("Right Elbow on Part " + RightHandBend) : "Right Elbow");
			d.OnValueLabelRequested(() => _leftFootTarget, (bool x) => (LeftFootTarget != -1) ? ("Left Foot on Part " + LeftFootTarget) : "Left Foot");
			d.OnValueLabelRequested(() => _rightFootTarget, (bool x) => (RightFootTarget != -1) ? ("Right Foot on Part " + RightFootTarget) : "Right Foot");
			d.OnValueLabelRequested(() => _leftFootBend, (bool x) => (LeftFootBend != -1) ? ("Left Knee on Part " + LeftFootBend) : "Left Knee");
			d.OnValueLabelRequested(() => _rightFootBend, (bool x) => (RightFootBend != -1) ? ("Right Knee on Part " + RightFootBend) : "Right Knee");
			d.OnPropertyChanged(() => _forwardLook, delegate
			{
				base.Script.UpdatePilot();
			});
			d.OnPropertyChanged(() => _leftHandTarget, delegate
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ChangeIKTarget(1, LeftHandTarget);
				});
			});
			d.OnPropertyChanged(() => _rightHandTarget, delegate
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ChangeIKTarget(2, RightHandTarget);
				});
			});
			d.OnPropertyChanged(() => _leftHandBend, delegate
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ChangeIKTarget(3, LeftHandBend);
				});
			});
			d.OnPropertyChanged(() => _rightHandBend, delegate
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ChangeIKTarget(4, RightHandBend);
				});
			});
			d.OnPropertyChanged(() => _leftFootTarget, delegate
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ChangeIKTarget(5, LeftFootTarget);
				});
			});
			d.OnPropertyChanged(() => _rightFootTarget, delegate
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ChangeIKTarget(6, RightFootTarget);
				});
			});
			d.OnPropertyChanged(() => _leftFootBend, delegate
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ChangeIKTarget(7, LeftFootBend);
				});
			});
			d.OnPropertyChanged(() => _rightFootBend, delegate
			{
				UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
				{
					ChangeIKTarget(8, RightFootBend);
				});
			});
		}

		private void ChangeIKTarget(int element, int targetID)
		{
			bool flag = true;
			if (element == 1 && LeftHandTarget >= 0)
			{
				LeftHandTarget = -1;
			}
			else if (element == 2 && RightHandTarget >= 0)
			{
				RightHandTarget = -1;
			}
			else if (element == 3 && LeftHandBend >= 0)
			{
				LeftHandBend = -1;
			}
			else if (element == 4 && RightHandBend >= 0)
			{
				RightHandBend = -1;
			}
			else if (element == 5 && LeftFootTarget >= 0)
			{
				LeftFootTarget = -1;
			}
			else if (element == 6 && RightFootTarget >= 0)
			{
				RightFootTarget = -1;
			}
			else if (element == 7 && LeftFootBend >= 0)
			{
				LeftFootBend = -1;
			}
			else if (element == 8 && RightFootBend >= 0)
			{
				RightFootBend = -1;
			}
			else
			{
				flag = false;
				Game.Instance.Designer.SelectPartTool.Activate((PartData p) => true, base.Part.PartScript.CraftScript.Data.Assembly.GetPartById(targetID), delegate(PartData p)
				{
					switch (element)
					{
					case 1:
						LeftHandTarget = p?.Id ?? (-1);
						break;
					case 2:
						RightHandTarget = p?.Id ?? (-1);
						break;
					case 3:
						LeftHandBend = p?.Id ?? (-1);
						break;
					case 4:
						RightHandBend = p?.Id ?? (-1);
						break;
					case 5:
						LeftFootTarget = p?.Id ?? (-1);
						break;
					case 6:
						RightFootTarget = p?.Id ?? (-1);
						break;
					case 7:
						LeftFootBend = p?.Id ?? (-1);
						break;
					case 8:
						RightFootBend = p?.Id ?? (-1);
						break;
					}
					base.Script.UpdatePilot(updateTargets: true);
					Game.Instance.Designer.SelectPart(base.Script.PartScript, null, justAdded: false);
				}, null);
			}
			if (flag)
			{
				base.Script.UpdatePilot(updateTargets: true);
				Game.Instance.Designer.SelectPart(base.Script.PartScript, null, justAdded: false);
			}
		}

		private void InvokeParametersChangedOnSymmetricPartModifiers(bool synchronizePartModifiersFirst = true)
		{
			if (synchronizePartModifiersFirst)
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			}
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(EvaChairData modifier)
			{
				modifier.Script.UpdatePartStyle();
			});
		}
	}
}
