using System.Text;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace XCharts.Runtime
{
	public abstract class MainComponentHandler
	{
		public BaseChart chart { get; internal set; }

		public ComponentHandlerAttribute attribute { get; internal set; }

		public virtual void InitComponent()
		{
		}

		public virtual void RemoveComponent()
		{
		}

		public virtual void CheckComponent(StringBuilder sb)
		{
		}

		public virtual void Update()
		{
		}

		public virtual void DrawBase(VertexHelper vh)
		{
		}

		public virtual void DrawUpper(VertexHelper vh)
		{
		}

		public virtual void DrawTop(VertexHelper vh)
		{
		}

		public virtual void OnSerieDataUpdate(int serieIndex)
		{
		}

		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		public virtual void OnPointerDown(PointerEventData eventData)
		{
		}

		public virtual void OnPointerUp(PointerEventData eventData)
		{
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		public virtual void OnScroll(PointerEventData eventData)
		{
		}

		internal abstract void SetComponent(MainComponent component);
	}
	public abstract class MainComponentHandler<T> : MainComponentHandler where T : MainComponent
	{
		public T component { get; internal set; }

		internal override void SetComponent(MainComponent component)
		{
			this.component = (T)component;
		}
	}
}
