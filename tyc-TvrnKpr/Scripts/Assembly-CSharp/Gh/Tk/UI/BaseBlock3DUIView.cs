using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class BaseBlock3DUIView : MonoBehaviour
	{
		public interface IEarlyColliderResizable : IColliderResizable
		{
		}

		public interface IEarlyRectResizable : IRectResizable
		{
		}

		public interface IColliderResizable
		{
			void ResizeColliderToContent();

			float GetColliderWidth();
		}

		public interface IRectResizable
		{
			void ResizeToContent(float maxWidth);

			float GetRectWidth();
		}

		public interface ILateColliderResizable
		{
			void ResizeColliderToMaxWidth(float maxWidth);
		}

		public interface IFullWidthResizeable
		{
			void ResizeToWidth(float width);
		}

		private BoxCollider _layoutCollider;

		public string blockType;

		[SerializeField]
		private List<Renderer> _ignoredRenderers;

		public BoxCollider LayoutCollider => null;

		public void DestroyBlock()
		{
		}

		public virtual void SetBlockData(string data)
		{
		}

		public IEnumerable<Renderer> GetIgnoredRenderers()
		{
			return null;
		}
	}
}
