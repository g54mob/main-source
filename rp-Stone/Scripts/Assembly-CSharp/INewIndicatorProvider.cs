using UnityEngine;

public interface INewIndicatorProvider
{
	bool IsNewIndicating();

	Color GetNewIndicatorColor();

	string GetNewIndicatorString();
}
