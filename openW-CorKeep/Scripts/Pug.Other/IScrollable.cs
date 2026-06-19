public interface IScrollable
{
	void UpdateContainingElements(float scroll);

	bool IsBottomElementSelected();

	bool IsTopElementSelected();

	float GetCurrentWindowHeight();
}
