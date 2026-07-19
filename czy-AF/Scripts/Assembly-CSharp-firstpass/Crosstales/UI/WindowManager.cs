using UnityEngine;

namespace Crosstales.UI
{
	public class WindowManager : MonoBehaviour
	{
		[Tooltip("Window movement speed (default: 3).")]
		public float Speed = 3f;

		[Tooltip("Dependent GameObjects (active == open).")]
		public GameObject[] Dependencies;

		private UIFocus focus;

		private bool open;

		private bool close;

		private Vector3 startPos;

		private Vector3 centerPos;

		private Vector3 lerpPos;

		private float openProgress;

		private float closeProgress;

		private GameObject panel;

		private Transform tf;

		public void Start()
		{
			tf = base.transform;
			panel = tf.Find("Panel").gameObject;
			startPos = tf.position;
			ClosePanel();
			panel.SetActive(value: false);
			if (Dependencies != null)
			{
				GameObject[] dependencies = Dependencies;
				for (int i = 0; i < dependencies.Length; i++)
				{
					dependencies[i].SetActive(value: false);
				}
			}
		}

		public void Update()
		{
			centerPos = new Vector3((float)Screen.width / 2f, (float)Screen.height / 2f, 0f);
			if (open && openProgress < 1f)
			{
				openProgress += Speed * Time.deltaTime;
				tf.position = Vector3.Lerp(lerpPos, centerPos, openProgress);
			}
			else
			{
				if (!close)
				{
					return;
				}
				if (closeProgress < 1f)
				{
					closeProgress += Speed * Time.deltaTime;
					tf.position = Vector3.Lerp(lerpPos, startPos, closeProgress);
					return;
				}
				panel.SetActive(value: false);
				if (Dependencies != null)
				{
					GameObject[] dependencies = Dependencies;
					for (int i = 0; i < dependencies.Length; i++)
					{
						dependencies[i].SetActive(value: false);
					}
				}
			}
		}

		public void SwitchPanel()
		{
			if (open)
			{
				ClosePanel();
			}
			else
			{
				OpenPanel();
			}
		}

		public void OpenPanel()
		{
			panel.SetActive(value: true);
			if (Dependencies != null)
			{
				GameObject[] dependencies = Dependencies;
				for (int i = 0; i < dependencies.Length; i++)
				{
					dependencies[i].SetActive(value: true);
				}
			}
			focus = base.gameObject.GetComponent<UIFocus>();
			focus.OnPanelEnter();
			lerpPos = tf.position;
			open = true;
			close = false;
			openProgress = 0f;
		}

		public void ClosePanel()
		{
			lerpPos = tf.position;
			open = false;
			close = true;
			closeProgress = 0f;
		}
	}
}
