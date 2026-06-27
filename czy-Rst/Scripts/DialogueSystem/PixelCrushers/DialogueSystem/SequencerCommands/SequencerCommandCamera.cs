using UnityEngine;

namespace PixelCrushers.DialogueSystem.SequencerCommands
{
	[AddComponentMenu("")]
	public class SequencerCommandCamera : SequencerCommand
	{
		private const float SmoothMoveCutoff = 0.05f;

		private Transform subject;

		private Transform angleTransform;

		private Transform cameraTransform;

		private bool isLocalTransform;

		private Quaternion targetRotation;

		private Vector3 targetPosition;

		private float duration;

		private float startTime;

		private float endTime;

		private Quaternion originalRotation;

		private Vector3 originalPosition;

		public void Start()
		{
			string text = GetParameter(0, "Closeup");
			subject = GetSubject(1);
			duration = GetParameterAsFloat(2);
			if (string.Equals(text, "default"))
			{
				text = SequencerTools.GetDefaultCameraAngle(subject);
			}
			bool flag = string.Equals(text, "original");
			angleTransform = ((!flag) ? ((base.sequencer.cameraAngles != null) ? base.sequencer.cameraAngles.transform.Find(text) : null) : ((Camera.main != null) ? Camera.main.transform : base.speaker));
			isLocalTransform = true;
			if (angleTransform == null)
			{
				isLocalTransform = false;
				GameObject gameObject = GameObject.Find(text);
				if (gameObject != null)
				{
					angleTransform = gameObject.transform;
				}
			}
			if (angleTransform == null && DialogueDebug.logWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: Camera({1}): Camera angle '{2}' wasn't found.", new object[3]
				{
					"Dialogue System",
					GetParameters(),
					text
				}));
			}
			else if (subject == null && !flag && (!isLocalTransform || !(angleTransform != null)) && DialogueDebug.logWarnings)
			{
				Debug.LogWarning(string.Format("{0}: Sequencer: Camera({1}): Camera subject '{2}' or GameObject named '{3}' wasn't found.", "Dialogue System", GetParameters(), GetParameter(1), GetParameter(0)));
			}
			else if (DialogueDebug.logInfo)
			{
				Debug.Log(string.Format("{0}: Sequencer: Camera({1}, {2}, {3}s)", "Dialogue System", text, Tools.GetGameObjectName(subject), duration));
			}
			base.sequencer.TakeCameraControl();
			if (flag || (angleTransform != null && (subject != null || isLocalTransform)))
			{
				cameraTransform = base.sequencer.sequencerCameraTransform;
				if (flag)
				{
					targetRotation = base.sequencer.originalCameraRotation;
					targetPosition = base.sequencer.originalCameraPosition;
				}
				else if (isLocalTransform)
				{
					targetRotation = subject.rotation * angleTransform.localRotation;
					targetPosition = subject.position + subject.rotation * angleTransform.localPosition;
				}
				else
				{
					targetRotation = angleTransform.rotation;
					targetPosition = angleTransform.position;
				}
				if (duration > 0.05f)
				{
					startTime = DialogueTime.time;
					endTime = startTime + duration;
					originalRotation = cameraTransform.rotation;
					originalPosition = cameraTransform.position;
				}
				else
				{
					Stop();
				}
			}
			else
			{
				Stop();
			}
		}

		public void Update()
		{
			if (DialogueTime.time < endTime)
			{
				float t = (DialogueTime.time - startTime) / duration;
				cameraTransform.rotation = Quaternion.Lerp(originalRotation, targetRotation, t);
				cameraTransform.position = Vector3.Lerp(originalPosition, targetPosition, t);
			}
			else
			{
				Stop();
			}
		}

		public void OnDestroy()
		{
			if (angleTransform != null && subject != null)
			{
				cameraTransform.rotation = targetRotation;
				cameraTransform.position = targetPosition;
			}
		}
	}
}
