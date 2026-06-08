using System.Collections.Generic;
using UnityEngine;

public class HUDCameraController : MonoBehaviour
{
	private class DroneProperties
	{
		public int DroneNumber = -1;

		public bool isDegaussPlaying;

		public bool isStaticOnDisabled;

		public bool isStaticOnDamage;

		public bool isCompressingOnRadiation;

		public bool isGlitchingOnDamage;

		public int currentStaticIdx = -1;

		public float staticDisabledStrengthFactor = 1f;

		public float compressionFade;

		public float compressionAngle;

		public float glitchStrengthX;

		public float glitchStrengthY;

		public float staticTimerOnDamage;

		public float staticDamagedStrengthFactor = 1f;
	}

	public static HUDCameraController Instance;

	public PostAnimator DegaussAnimator;

	public PostAnimator StaticAnimator;

	public PostAnimator CompressionAnimator;

	public Static StaticShader;

	public Compression CompressionShader;

	public GlitchOffset GlitchOffsetShader;

	public Degauss DegaussShader;

	public int StaticStartIdx = 1;

	public int StaticIdleFwdIdx = 2;

	public int StaticIdleHoldIdx = 5;

	public int StaticIdleBackIdx = 4;

	public int StaticPopIdx = 3;

	public int StaticPopChance = 20;

	public int StaticIdleHoldChance = 80;

	public int StaticIdleHoldContinueChance = 20;

	private List<DroneProperties> dronePropertyList;

	private AnimFloat currentDegaussAnim;

	private AnimFloat currentStaticAnim;

	private AnimFloat currentCompressionAnim;

	private bool atLeastOneDegauss;

	private bool atLeastOneStaticOnDisabled;

	private bool atLeastOneStaticOnDamaged;

	private bool atLeastOneCompression;

	private int currentDroneNumber = -1;

	public void Awake()
	{
		Instance = this;
		StaticShader.enabled = false;
		CompressionShader.enabled = false;
		GlitchOffsetShader.enabled = false;
		DegaussShader.enabled = false;
	}

	private void OnDestroy()
	{
		DegaussAnimator = null;
		StaticAnimator = null;
		CompressionAnimator = null;
		StaticShader = null;
		CompressionShader = null;
		GlitchOffsetShader = null;
		DegaussShader = null;
	}

	public void Degauss(int droneNumber)
	{
		if (!(DegaussAnimator != null))
		{
			return;
		}
		int index = Random.Range(0, DegaussAnimator.animations.Count);
		if (dronePropertyList == null)
		{
			dronePropertyList = new List<DroneProperties>();
		}
		DroneProperties droneProperties = null;
		if (dronePropertyList != null)
		{
			int count = dronePropertyList.Count;
			for (int i = 0; i < count; i++)
			{
				if (dronePropertyList[i].DroneNumber == droneNumber)
				{
					droneProperties = dronePropertyList[i];
					break;
				}
			}
		}
		if (droneProperties == null)
		{
			droneProperties = new DroneProperties();
			droneProperties.DroneNumber = droneNumber;
			dronePropertyList.Add(droneProperties);
		}
		else if (droneProperties.isDegaussPlaying)
		{
			return;
		}
		droneProperties.isDegaussPlaying = true;
		if (DroneManager.Instance.CurrentDrone.DroneNumber == droneNumber)
		{
			DegaussShader.enabled = true;
			currentDegaussAnim = DegaussAnimator.animations[index];
			currentDegaussAnim.Play();
		}
		atLeastOneDegauss = true;
	}

	public void SwitchToDrone(int droneNumber)
	{
		if (droneNumber == currentDroneNumber)
		{
			return;
		}
		DroneProperties droneProperties = null;
		if (dronePropertyList != null)
		{
			int count = dronePropertyList.Count;
			for (int i = 0; i < count; i++)
			{
				if (dronePropertyList[i].DroneNumber == droneNumber)
				{
					droneProperties = dronePropertyList[i];
					break;
				}
			}
		}
		if (droneProperties == null)
		{
			if (currentStaticAnim != null && currentStaticAnim.isPlaying)
			{
				currentStaticAnim.Stop();
			}
			StaticShader.strength = 0f;
			StaticShader.sample = 0f;
			StaticShader.enabled = false;
			CompressionShader.fade = 0f;
			CompressionShader.angle = 0f;
			CompressionShader.enabled = false;
			GlitchOffsetShader.xStrength = 0f;
			GlitchOffsetShader.yStrength = 0f;
			GlitchOffsetShader.enabled = false;
		}
		else
		{
			if (!droneProperties.isStaticOnDisabled)
			{
				if (!droneProperties.isStaticOnDamage && currentStaticAnim != null && currentStaticAnim.isPlaying)
				{
					currentStaticAnim.Stop();
					droneProperties.staticDisabledStrengthFactor = 1f;
					StaticShader.strength = 0f;
					StaticShader.sample = 0f;
					StaticShader.enabled = false;
				}
			}
			else
			{
				currentStaticAnim = StaticAnimator.animations[droneProperties.currentStaticIdx];
				currentStaticAnim.obj = StaticShader;
				StaticShader.StrengthFactor = droneProperties.staticDisabledStrengthFactor;
				StaticShader.enabled = true;
				currentStaticAnim.Play();
			}
			if (!droneProperties.isStaticOnDamage)
			{
				if (!droneProperties.isStaticOnDisabled)
				{
					droneProperties.staticTimerOnDamage = 0f;
					droneProperties.staticDamagedStrengthFactor = 0f;
					StaticShader.strength = 0f;
					StaticShader.enabled = false;
				}
			}
			else
			{
				StaticShader.strength = droneProperties.staticDamagedStrengthFactor;
			}
			if (!droneProperties.isCompressingOnRadiation)
			{
				droneProperties.compressionFade = 0f;
				droneProperties.compressionAngle = 0f;
				CompressionShader.fade = 0f;
				CompressionShader.angle = 0f;
				CompressionShader.enabled = false;
			}
			else
			{
				CompressionShader.fade = droneProperties.compressionFade;
				CompressionShader.angle = droneProperties.compressionAngle;
				CompressionShader.enabled = true;
			}
			if (!droneProperties.isGlitchingOnDamage)
			{
				GlitchOffsetShader.xStrength = 0f;
				GlitchOffsetShader.yStrength = 0f;
				GlitchOffsetShader.enabled = false;
			}
			else
			{
				GlitchOffsetShader.xStrength = droneProperties.glitchStrengthX;
				GlitchOffsetShader.yStrength = droneProperties.glitchStrengthY;
				GlitchOffsetShader.enabled = true;
			}
		}
		currentDroneNumber = droneNumber;
	}

	public void FireCompression(int droneNumber)
	{
		if (dronePropertyList == null)
		{
			dronePropertyList = new List<DroneProperties>();
		}
		DroneProperties droneProperties = null;
		int count = dronePropertyList.Count;
		for (int i = 0; i < count; i++)
		{
			if (dronePropertyList[i].DroneNumber == droneNumber)
			{
				droneProperties = dronePropertyList[i];
				break;
			}
		}
		if (droneProperties == null)
		{
			droneProperties = new DroneProperties();
			droneProperties.DroneNumber = droneNumber;
			dronePropertyList.Add(droneProperties);
		}
		else if (droneProperties.isCompressingOnRadiation)
		{
			return;
		}
		droneProperties.isCompressingOnRadiation = true;
		droneProperties.compressionFade = 0.5f;
		if (DroneManager.Instance.CurrentDrone.DroneNumber == droneNumber)
		{
			CompressionShader.fade = droneProperties.compressionFade;
		}
		droneProperties.compressionAngle = Random.Range(-180f, 180f);
		if (DroneManager.Instance.CurrentDrone.DroneNumber == droneNumber)
		{
			CompressionShader.angle = droneProperties.compressionAngle;
			CompressionShader.enabled = true;
			currentDroneNumber = droneNumber;
		}
	}

	public void FireGlitchOnDamage(int droneNumber)
	{
		if (dronePropertyList == null)
		{
			dronePropertyList = new List<DroneProperties>();
		}
		DroneProperties droneProperties = null;
		int count = dronePropertyList.Count;
		for (int i = 0; i < count; i++)
		{
			if (dronePropertyList[i].DroneNumber == droneNumber)
			{
				droneProperties = dronePropertyList[i];
				break;
			}
		}
		if (droneProperties == null)
		{
			droneProperties = new DroneProperties();
			droneProperties.DroneNumber = droneNumber;
			dronePropertyList.Add(droneProperties);
		}
		else if (droneProperties.isGlitchingOnDamage)
		{
			return;
		}
		droneProperties.isGlitchingOnDamage = true;
		droneProperties.glitchStrengthX = 0.01f;
		droneProperties.glitchStrengthY = 0.01f;
		if (DroneManager.Instance.CurrentDrone.DroneNumber == droneNumber)
		{
			GlitchOffsetShader.xStrength = droneProperties.glitchStrengthX;
			GlitchOffsetShader.yStrength = droneProperties.glitchStrengthY;
			GlitchOffsetShader.enabled = true;
			currentDroneNumber = droneNumber;
		}
	}

	public void FireStaticOnDisabled(int droneNumber)
	{
		if (dronePropertyList == null)
		{
			dronePropertyList = new List<DroneProperties>();
		}
		DroneProperties droneProperties = null;
		int count = dronePropertyList.Count;
		for (int i = 0; i < count; i++)
		{
			if (dronePropertyList[i].DroneNumber == droneNumber)
			{
				droneProperties = dronePropertyList[i];
				break;
			}
		}
		if (droneProperties == null)
		{
			droneProperties = new DroneProperties();
			droneProperties.DroneNumber = droneNumber;
			dronePropertyList.Add(droneProperties);
		}
		droneProperties.currentStaticIdx = StaticStartIdx;
		droneProperties.staticDisabledStrengthFactor = 1f;
		droneProperties.isStaticOnDisabled = true;
		if (DroneManager.Instance.CurrentDrone != null && DroneManager.Instance.CurrentDrone.DroneNumber == droneNumber)
		{
			StaticShader.StrengthFactor = droneProperties.staticDisabledStrengthFactor;
			StaticShader.enabled = true;
			currentStaticAnim = StaticAnimator.animations[droneProperties.currentStaticIdx];
			currentStaticAnim.obj = StaticShader;
			currentStaticAnim.Play();
			currentDroneNumber = droneNumber;
		}
		atLeastOneStaticOnDisabled = true;
	}

	public void FireStaticOnDamage(int droneNumber, float strength)
	{
		if (dronePropertyList == null)
		{
			dronePropertyList = new List<DroneProperties>();
		}
		DroneProperties droneProperties = null;
		int count = dronePropertyList.Count;
		for (int i = 0; i < count; i++)
		{
			if (dronePropertyList[i].DroneNumber == droneNumber)
			{
				droneProperties = dronePropertyList[i];
				break;
			}
		}
		if (droneProperties == null)
		{
			droneProperties = new DroneProperties();
			droneProperties.DroneNumber = droneNumber;
			dronePropertyList.Add(droneProperties);
		}
		if (!droneProperties.isStaticOnDamage)
		{
			droneProperties.isStaticOnDamage = true;
			droneProperties.staticDamagedStrengthFactor = strength;
			droneProperties.staticTimerOnDamage = 0.25f;
			if (DroneManager.Instance.CurrentDrone.DroneNumber == droneNumber)
			{
				StaticShader.strength = droneProperties.staticDamagedStrengthFactor;
				StaticShader.enabled = true;
				currentDroneNumber = droneNumber;
			}
			atLeastOneStaticOnDamaged = true;
		}
	}

	private void Update()
	{
		if (dronePropertyList == null)
		{
			return;
		}
		if (atLeastOneStaticOnDisabled)
		{
			int count = dronePropertyList.Count;
			for (int i = 0; i < count; i++)
			{
				if (dronePropertyList[i].DroneNumber != currentDroneNumber)
				{
					continue;
				}
				if (!dronePropertyList[i].isStaticOnDisabled)
				{
					break;
				}
				if (currentStaticAnim.isPlaying)
				{
					continue;
				}
				if (dronePropertyList[i].currentStaticIdx == StaticStartIdx)
				{
					dronePropertyList[i].currentStaticIdx = StaticIdleFwdIdx;
				}
				else if (dronePropertyList[i].currentStaticIdx == StaticIdleFwdIdx)
				{
					if (Random.Range(0, 100) < StaticPopChance)
					{
						dronePropertyList[i].currentStaticIdx = StaticPopIdx;
					}
					else if (Random.Range(0, 100) < StaticIdleHoldChance)
					{
						dronePropertyList[i].currentStaticIdx = StaticIdleHoldIdx;
					}
					else
					{
						dronePropertyList[i].currentStaticIdx = StaticIdleBackIdx;
					}
				}
				else if (dronePropertyList[i].currentStaticIdx == StaticIdleBackIdx)
				{
					dronePropertyList[i].currentStaticIdx = StaticIdleFwdIdx;
				}
				else if (dronePropertyList[i].currentStaticIdx == StaticIdleHoldIdx)
				{
					if (Random.Range(0, 100) < StaticPopChance)
					{
						dronePropertyList[i].currentStaticIdx = StaticPopIdx;
					}
					else if (Random.Range(0, 100) < StaticIdleHoldContinueChance)
					{
						dronePropertyList[i].currentStaticIdx = StaticIdleHoldIdx;
					}
					else
					{
						dronePropertyList[i].currentStaticIdx = StaticIdleBackIdx;
					}
				}
				else if (dronePropertyList[i].currentStaticIdx == StaticPopIdx)
				{
					dronePropertyList[i].currentStaticIdx = StaticIdleFwdIdx;
				}
				currentStaticAnim = StaticAnimator.animations[dronePropertyList[i].currentStaticIdx];
				currentStaticAnim.obj = StaticShader;
				currentStaticAnim.Play();
			}
		}
		if (atLeastOneStaticOnDamaged)
		{
			int count2 = dronePropertyList.Count;
			for (int j = 0; j < count2; j++)
			{
				if (!dronePropertyList[j].isStaticOnDamage)
				{
					continue;
				}
				dronePropertyList[j].staticTimerOnDamage -= Time.deltaTime;
				if (!(dronePropertyList[j].staticTimerOnDamage <= 0f))
				{
					continue;
				}
				dronePropertyList[j].staticTimerOnDamage = 0f;
				dronePropertyList[j].isStaticOnDamage = false;
				dronePropertyList[j].staticDamagedStrengthFactor = 0f;
				if (dronePropertyList[j].DroneNumber == currentDroneNumber)
				{
					StaticShader.strength = dronePropertyList[j].staticDamagedStrengthFactor;
					StaticShader.enabled = false;
				}
				bool flag = false;
				for (int k = 0; k < count2; k++)
				{
					if (dronePropertyList[k].DroneNumber != dronePropertyList[j].DroneNumber && dronePropertyList[k].isStaticOnDamage)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					atLeastOneStaticOnDamaged = false;
				}
			}
		}
		if (atLeastOneDegauss)
		{
			int count3 = dronePropertyList.Count;
			for (int l = 0; l < count3; l++)
			{
				if (dronePropertyList[l].DroneNumber != currentDroneNumber)
				{
					continue;
				}
				if (!dronePropertyList[l].isDegaussPlaying)
				{
					break;
				}
				if (!currentDegaussAnim.isPlaying)
				{
					if (currentCompressionAnim != null && currentCompressionAnim.isPlaying)
					{
						currentCompressionAnim.Stop();
					}
					if (dronePropertyList[l].isCompressingOnRadiation)
					{
						dronePropertyList[l].isCompressingOnRadiation = false;
						dronePropertyList[l].compressionFade = 0f;
						dronePropertyList[l].compressionAngle = 0f;
						CompressionShader.fade = 0.1f;
						CompressionShader.angle = 0f;
						CompressionShader.enabled = false;
					}
					if (dronePropertyList[l].isGlitchingOnDamage)
					{
						dronePropertyList[l].isGlitchingOnDamage = false;
						dronePropertyList[l].glitchStrengthX = 0f;
						dronePropertyList[l].glitchStrengthY = 0f;
						GlitchOffsetShader.xStrength = 0f;
						GlitchOffsetShader.yStrength = 0f;
						GlitchOffsetShader.enabled = false;
					}
					currentDegaussAnim = null;
					StaticShader.strength = 0f;
					StaticShader.sample = 0f;
					StaticShader.enabled = false;
					dronePropertyList[l].isStaticOnDisabled = false;
					dronePropertyList[l].isDegaussPlaying = false;
					DegaussShader.enabled = false;
					atLeastOneDegauss = false;
					break;
				}
				float t = currentDegaussAnim.animationTime / (float)currentDegaussAnim.animation.length;
				if (dronePropertyList[l].isStaticOnDisabled)
				{
					dronePropertyList[l].staticDisabledStrengthFactor = Mathf.Lerp(dronePropertyList[l].staticDisabledStrengthFactor, 0f, t);
					StaticShader.StrengthFactor = dronePropertyList[l].staticDisabledStrengthFactor;
				}
				if (dronePropertyList[l].isCompressingOnRadiation)
				{
					dronePropertyList[l].compressionFade = Mathf.Lerp(dronePropertyList[l].compressionFade, 0f, t);
					CompressionShader.fade = dronePropertyList[l].compressionFade;
				}
				if (dronePropertyList[l].isGlitchingOnDamage)
				{
					dronePropertyList[l].glitchStrengthX = Mathf.Lerp(dronePropertyList[l].glitchStrengthX, 0f, t);
					dronePropertyList[l].glitchStrengthY = Mathf.Lerp(dronePropertyList[l].glitchStrengthX, 0f, t);
					GlitchOffsetShader.xStrength = dronePropertyList[l].glitchStrengthX;
					GlitchOffsetShader.yStrength = dronePropertyList[l].glitchStrengthY;
				}
			}
		}
		if (!atLeastOneCompression)
		{
			return;
		}
		int count4 = dronePropertyList.Count;
		for (int m = 0; m < count4; m++)
		{
			if (dronePropertyList[m].DroneNumber == currentDroneNumber)
			{
				if (!dronePropertyList[m].isCompressingOnRadiation)
				{
					break;
				}
				if (!currentCompressionAnim.isPlaying)
				{
					currentCompressionAnim = null;
					CompressionShader.fade = 0.1f;
					CompressionShader.angle = 0f;
					CompressionShader.enabled = false;
					dronePropertyList[m].isStaticOnDisabled = false;
					dronePropertyList[m].isDegaussPlaying = false;
					DegaussShader.enabled = false;
					atLeastOneDegauss = false;
					break;
				}
			}
		}
	}
}
