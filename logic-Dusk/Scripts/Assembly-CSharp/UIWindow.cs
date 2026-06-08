using UnityEngine;
using UnityEngine.UI;

public class UIWindow : MonoBehaviour
{
	public UITextLabel titleLabel;

	public UITextLabel bodyLabel;

	public Image screenDimImage;

	public bool IsShowing { get; protected set; }
}
