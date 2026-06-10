using TMPro;
using UnityEngine;

namespace NSMedieval.FloatingOverlaySystem
{
	public abstract class PriorityTextPopupFloatingElement : FloatingElementBase
	{
		[SerializeField]
		private FlyUpEffect textTemplateObject;

		private float recursionPreventor;

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Holder.OnNewElementAddedEvent -= OnElementAdded;
				base.Holder.OnElementIndexChangedEvent -= OnElementIndexChanged;
				base.Dispose();
			}
		}

		protected override void Start()
		{
			base.Start();
			base.Holder.OnNewElementAddedEvent += OnElementAdded;
			base.Holder.OnElementIndexChangedEvent += OnElementIndexChanged;
		}

		protected void InstantiatePopupTextElement(string text, Color color = default(Color))
		{
			GameObject obj = Object.Instantiate(textTemplateObject.gameObject, base.transform);
			obj.transform.localPosition = textTemplateObject.transform.localPosition;
			TextMeshProUGUI component = obj.GetComponent<TextMeshProUGUI>();
			component.text = text;
			if (!color.Equals(default(Color)))
			{
				component.color = color;
			}
			obj.SetActive(value: true);
		}

		private void OnElementAdded(FloatingElementBase element)
		{
			if (GetIndex() != base.Holder.ElementsCount - 1)
			{
				SetIndex(base.Holder.ElementsCount - 1);
			}
		}

		private void OnElementIndexChanged(FloatingElementBase element)
		{
			if (!(element == this) && !(element is PriorityTextPopupFloatingElement) && !(Time.time - recursionPreventor <= 0.01f) && GetIndex() != base.Holder.ElementsCount - 1)
			{
				SetIndex(base.Holder.ElementsCount - 1);
				recursionPreventor = Time.time;
			}
		}
	}
}
