using UnityEngine.UI;

public interface ISelectableGroupFirstSelectedProvider
{
	bool TryGetFirstSelected(out Selectable selectable);
}
