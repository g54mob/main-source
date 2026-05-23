using UnityEngine;

public class AnimEventHandler : MonoBehaviour
{
	public interface IHost
	{
		void OnAnimEvent(string id);
	}

	public IHost host;

	public string firstTokenFilter;

	public void OnAnimEvent(AnimationEvent e)
	{
		string stringParameter = e.stringParameter;
		if (host != null)
		{
			if (firstTokenFilter != null)
			{
				int num = stringParameter.IndexOf(' ');
				if (num >= 0)
				{
					string text = stringParameter.Substring(0, num);
					if (!(text.ToLower() != firstTokenFilter))
					{
						host.OnAnimEvent(stringParameter.Substring(num + 1));
					}
				}
			}
			else
			{
				host.OnAnimEvent(stringParameter);
			}
		}
		else if (base.transform.parent != null)
		{
			base.transform.parent.SendMessage("OnAnimEvent", stringParameter);
		}
	}

	public static void Attach(GameObject animatedObject, IHost host, string firstTokenFilter = null)
	{
		AnimEventHandler animEventHandler = animatedObject.AddComponent<AnimEventHandler>();
		animEventHandler.host = host;
		animEventHandler.firstTokenFilter = ((firstTokenFilter == null) ? null : firstTokenFilter.ToLower());
	}
}
