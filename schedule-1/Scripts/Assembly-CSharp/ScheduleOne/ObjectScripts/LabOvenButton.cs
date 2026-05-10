using ScheduleOne.Misc;
using ScheduleOne.PlayerTasks;
using UnityEngine;

namespace ScheduleOne.ObjectScripts
{
	public class LabOvenButton : MonoBehaviour
	{
		private const float ANIMATION_TIME = 0.2f;

		public Transform Button;

		public Transform PressedTransform;

		public Transform DepressedTransform;

		public ToggleableLight Light;

		public Clickable Clickable;

		private float animationTimer;

		private Vector3 animationStartPos;

		private Vector3 animationEndPos;

		public bool Pressed { get; private set; }

		private void Start()
		{
		}

		public void SetInteractable(bool interactable)
		{
		}

		public void Press(RaycastHit hit)
		{
		}

		public void SetPressed(bool pressed)
		{
		}

		private void Update()
		{
		}
	}
}
