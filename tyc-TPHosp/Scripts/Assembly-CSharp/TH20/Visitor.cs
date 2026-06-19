using TH20.BT_Types;
using UnityEngine;

namespace TH20
{
	public class Visitor : Character
	{
		public enum Mode
		{
			Touring = 0,
			LeavingHospital = 1
		}

		public new VisitorDefinition Definition { get; private set; }

		public Mode CurrentMode { get; private set; }

		public Visitor(VisitorDefinition definition, Level level, VisualManager visualManager, int id, Vector3 position)
			: base(definition, level, visualManager, definition.Sex, definition.Name, id, position, navDisabled: false)
		{
			Definition = definition;
			CurrentMode = Mode.Touring;
			base.Visual.GenerateDefaultModular();
			if (base.Level.CharacterManager.NeverSpawnPatients)
			{
				RemoveComponents<CharacterCheckInComponent>();
				SetBehaviour(Definition._behaviourPostCheckIn);
			}
			else
			{
				SetBehaviour(Definition.InitialBehaviour);
			}
			InitializeComponents();
			UpdateStatusIcon();
		}

		public override void Update(float timeDelta)
		{
			base.Update(timeDelta);
			HasCheckInTimedOut();
			if (base.CurrentBehaviour == null)
			{
				GetComponent<VIPComponent>()?.OnVisitorHasNoBehaviour();
			}
			UpdateStatusIcon();
		}

		private void HasCheckInTimedOut()
		{
			if (GetComponent<CharacterCheckInComponent>() != null && base.TotalTimeInHospital > (double)GameAlgorithms.Config.MaxTimeVisitorsWaitForReceptionInSeconds)
			{
				LeaveHospital(ReasonForLeavingHospital.None);
			}
		}

		protected override void SetBehaviourVariables(CharacterBehaviorTree behaviorTree)
		{
			base.SetBehaviourVariables(behaviorTree);
			base.BehaviorTree.SetVariable("Visitor", new VisitorRef(this));
		}

		public string GetGUIActionText()
		{
			VIPComponent component = GetComponent<VIPComponent>();
			if (component != null)
			{
				return component.GetGUIActionText();
			}
			return string.Empty;
		}

		public Sprite GetStatusSprite()
		{
			return GetComponent<VIPComponent>()?.GetStatusSprite();
		}

		public override StatusIcon.Type GetStatusIcon()
		{
			if (GetComponent<VIPComponent>() != null)
			{
				return StatusIcon.Type.VIP;
			}
			return base.GetStatusIcon();
		}

		public override void DebugGUI()
		{
			base.DebugGUI();
			if (!base.ShowDebugInfo)
			{
				return;
			}
			GUIStyle gUIStyle = new GUIStyle(GUI.skin.box);
			Vector3 position = base.Position + Vector3.up * 2f;
			Vector3 vector = Camera.main.WorldToScreenPoint(position);
			VIPComponent component = GetComponent<VIPComponent>();
			string empty = string.Empty;
			empty = empty + "Name: " + base.Name;
			empty = empty + "\nMode: " + CurrentMode;
			empty = empty + "\nGoing to: " + base.GoingToRoom;
			empty = empty + "\nUsing: " + base.RoomUsing;
			empty = empty + "\n" + ((base.BehaviorTree != null) ? base.BehaviorTree.name : "No behaviour!");
			empty = empty + "\n" + _attributes;
			if (component != null)
			{
				empty = empty + "\nAppraisal: " + component.Appraisal.CalculateCurrentScore();
			}
			if (base.Animator != null)
			{
				AnimatorClipInfo[] currentAnimatorClipInfo = base.Animator.GetCurrentAnimatorClipInfo(0);
				foreach (AnimatorClipInfo animatorClipInfo in currentAnimatorClipInfo)
				{
					empty += $"\nAnimation Clip: {animatorClipInfo.clip.name}";
				}
			}
			Vector2 vector2 = gUIStyle.CalcSize(new GUIContent(empty));
			GUI.Box(new Rect(vector.x - vector2.x / 2f, (float)Screen.height - vector.y - vector2.y, vector2.x, vector2.y), empty, gUIStyle);
		}

		public override void LeaveHospital(ReasonForLeavingHospital reason)
		{
			if (CurrentMode != Mode.LeavingHospital)
			{
				VIPComponent component = GetComponent<VIPComponent>();
				if (GetComponent<CharacterCheckInComponent>() != null)
				{
					component?.SubmitShortTourAppraisal();
				}
				CurrentMode = Mode.LeavingHospital;
				base.LeaveHospital(reason);
			}
		}

		public override void EvictedFromRoom(Room room)
		{
		}

		protected override void OnRoomBecameInvalid(Room room)
		{
		}
	}
}
