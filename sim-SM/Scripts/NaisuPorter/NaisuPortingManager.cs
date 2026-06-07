using System.Runtime.CompilerServices;
using UnityEngine;

public class NaisuPortingManager : MonoBehaviour
{
	public delegate void SplashScreenTriggerer();

	[HideInInspector]
	public bool Initialized;

	[Header("Splash Screen")]
	[SerializeField]
	private GameObject splashScreenPrefab;

	[SerializeField]
	private GameObject splashCanvas;

	[Header("Commons")]
	[Tooltip("Do not leave any whitespaces.")]
	[SerializeField]
	private string DirectoryName;

	public static NaisuPortingManager Instance;

	public static event SplashScreenTriggerer OnSplashScreenTriggered
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void InstantiateSplashScreen()
	{
	}
}
