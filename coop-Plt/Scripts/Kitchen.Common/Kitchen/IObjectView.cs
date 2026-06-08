using UnityEngine;

namespace Kitchen
{
	public interface IObjectView
	{
		GameObject GameObject { get; }

		void Remove();

		void Initialise();

		void PerformUpdate();

		void SetPosition(UpdateViewPositionData pos);

		CPosition GetPosition();

		void SetHeldItem(IObjectView held_item, int storage_index, bool is_tool);

		void ParentDestroyed();

		void SetParent(Transform new_parent, bool set_active = true);

		T GetSubView<T>() where T : MonoBehaviour;
	}
}
