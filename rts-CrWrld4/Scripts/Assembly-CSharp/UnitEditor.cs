using UnityEngine;

public interface UnitEditor
{
	void ShowEditor(Transform inspector, UnitManager unit);

	void Apply();
}
