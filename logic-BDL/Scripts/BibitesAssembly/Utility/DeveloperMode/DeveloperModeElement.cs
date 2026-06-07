using UnityEngine;

namespace Utility.DeveloperMode
{
	public abstract class DeveloperModeElement : MonoBehaviour
	{
		protected RectTransform targetRT;

		protected RectTransform elementRT;

		protected bool developerMode;

		protected Vector2 elementOffset;

		protected void Awake()
		{
			elementRT = GetComponent<RectTransform>();
			InitElement();
		}

		protected virtual void InitElement()
		{
		}

		public virtual void SetTarget(RectTransform target)
		{
			targetRT = target;
		}

		public virtual void OnDeveloperModeChange(bool devMode)
		{
			developerMode = devMode;
		}
	}
}
