using UnityEngine;

namespace ModApi.Ui
{
	public abstract class DialogScript : MonoBehaviour, IDialog
	{
		public bool AllowCameraZoom { get; protected set; }

		public bool FadeInUponStart { get; set; }

		public virtual object UserData { get; set; }

		public event DialogDelegate Closed;

		public virtual void Close()
		{
			if (this.Closed != null)
			{
				this.Closed(this);
				this.Closed = null;
			}
		}

		protected virtual void Start()
		{
			RectTransform component = GetComponent<RectTransform>();
			component.offsetMin = new Vector2(0f, 0f);
			component.offsetMax = new Vector2(0f, 0f);
		}
	}
}
