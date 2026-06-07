using UnityEngine;
using UnityEngine.UI;

public class SaveIcon : MonoBehaviour
{
	public static SaveIcon Instance;

	public Image Icon;

	private float BeginTime;

	public float LiveTime;

	public float ColorSpeed;

	public Text Label;

	public AnimationCurve Fade;

	public Gradient ColorAnimation;

	private void Awake()
	{
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void Update()
	{
		Icon.color = ColorAnimation.Evaluate(Time.time % ColorSpeed / ColorSpeed);
		float num = Time.time - BeginTime;
		Icon.color = new Color(Icon.color.r, Icon.color.g, Icon.color.b, Fade.Evaluate(num / LiveTime));
		if (num > LiveTime)
		{
			base.gameObject.SetActive(false);
		}
	}

	public static void Show(string name)
	{
		if (Instance != null)
		{
			Instance.Label.text = name;
			Instance.BeginTime = Time.time;
			Instance.gameObject.SetActive(true);
		}
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}
}
