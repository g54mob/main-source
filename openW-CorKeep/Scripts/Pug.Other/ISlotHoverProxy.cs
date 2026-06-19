using System.Collections.Generic;

public interface ISlotHoverProxy
{
	IEnumerable<SlotUIBase> GetProxySlots();

	void SetHighliged(bool anySlotShouldBeProxied);
}
