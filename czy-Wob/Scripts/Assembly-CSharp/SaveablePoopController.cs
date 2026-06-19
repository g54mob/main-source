using System;

[Serializable]
public class SaveablePoopController
{
	public float poopMeter;

	public bool needsPoop;

	public bool isInPoopRoutine;

	public SaveablePoopController(DogPoopController p)
	{
		needsPoop = p.NeedsToPoop();
		poopMeter = p.GetPoopMeter();
		isInPoopRoutine = p.IsInPoopRoutine();
	}

	private SaveablePoopController()
	{
	}

	public SaveablePoopController GetCopy()
	{
		return new SaveablePoopController
		{
			poopMeter = poopMeter,
			needsPoop = needsPoop,
			isInPoopRoutine = isInPoopRoutine
		};
	}

	public void Load(DogPoopController p)
	{
		p.SetPoopMeter(poopMeter);
		p.SetNeedsToPoop(needsPoop);
		if (isInPoopRoutine)
		{
			p.StartPoopRoutine();
		}
	}
}
