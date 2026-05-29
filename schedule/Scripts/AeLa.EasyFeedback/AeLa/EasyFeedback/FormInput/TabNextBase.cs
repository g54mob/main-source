using AeLa.EasyFeedback.UI.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace AeLa.EasyFeedback.FormInput
{
	public abstract class TabNextBase : MonoBehaviour
	{
		public Selectable Next;

		public Selectable Previous;

		protected IInputField input;

		protected IInputField nextInput;

		protected IInputField previousInput;

		protected virtual void Start()
		{
		}

		protected virtual void Select(Selectable selectable)
		{
		}

		protected bool TryGetInputField(Selectable selectable, out IInputField field)
		{
			field = null;
			return false;
		}

		protected IInputField GetInputField(Selectable selectable)
		{
			return null;
		}

		public virtual void Copy(TabNextBase other)
		{
		}
	}
}
