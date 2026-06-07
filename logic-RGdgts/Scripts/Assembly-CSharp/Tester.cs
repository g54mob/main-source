using Sirenix.OdinInspector;
using UnityEngine;

public class Tester : SerializedMonoBehaviour, ILogOrigin
{
	public KeyCode desktopModeKey;

	public KeyCode autoScrollArchiveKey;

	public KeyCode autoBuildGadgetKey;

	public float autoScrollArchiveTime;

	public AnimationCurve autoScrollArchiveCurve;

	public MotherboardSectionEnum section;

	private void Update()
	{
	}

	public void DestroyHiddenInSceneRoot()
	{
	}

	public void CreateGadget()
	{
	}

	public void AddMotherboard()
	{
	}

	public void DestroyAllGadgets()
	{
	}

	public void TestScreenshoot()
	{
	}

	public void TestHologram()
	{
	}

	public void TestPrint()
	{
	}

	public void TestDestroy()
	{
	}

	public void TestStopProjector()
	{
	}

	public void TestShareGadget()
	{
	}

	public void TestUnpublishGadget()
	{
	}

	public void TestGetWorkshopGadgets()
	{
	}

	public void TestGetGadget()
	{
	}

	public void TestPrintSticker(Texture2D mask, PrintEffects effects, RectInt? rect)
	{
	}

	public void TestDestroySticker()
	{
	}

	public void TestDuplicatePrintedGadget()
	{
	}

	public void TestDuplicateLocalGadget(string newName)
	{
	}

	public void ToggleWebcamSec()
	{
	}

	public void ToggleNetworkSec()
	{
	}
}
