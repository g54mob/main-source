using UnityEngine;

public class StoveScript : MonoBehaviour
{
	public Furniture Parent;

	public Holdable TakeReady()
	{
		return Parent.GetHoldable((Holdable x) => x.MiscValue >= 1f);
	}

	public bool HasReady()
	{
		if (Parent.HasHoldables != 0)
		{
			return Parent.AnyHoldable((Holdable x) => x.MiscValue >= 1f);
		}
		return false;
	}

	private void FixedUpdate()
	{
		bool on = false;
		float sp = (Parent.HasUpg ? Parent.upg.Quality.MapRange(0f, 0.5f, 0.25f, 1f, true) : 1f);
		Parent.ForeachHoldable(delegate(Holdable x)
		{
			if (x.MiscValue < 1f)
			{
				on = true;
				x.MiscValue += Time.deltaTime * GameSettings.GameSpeed * sp / 15f;
			}
		});
		if (Parent.IsOn != on)
		{
			Parent.IsOn = on;
		}
	}
}
