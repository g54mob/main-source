using UnityEngine;

namespace AeLa.EasyFeedback
{
	public abstract class FormElement : MonoBehaviour
	{
		protected FeedbackForm Form;

		protected abstract void FormOpened();

		protected abstract void FormSubmitted();

		protected abstract void FormClosed();

		public virtual void Awake()
		{
		}
	}
}
