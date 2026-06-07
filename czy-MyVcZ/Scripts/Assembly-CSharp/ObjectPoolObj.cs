using UnityEngine;

public class ObjectPoolObj : MonoBehaviour
{
	private Transform _parent;

	public void Init(Transform trans)
	{
		_parent = trans;
	}

	public virtual void Spawn()
	{
		base.gameObject.SetActive(value: true);
	}

	public virtual void BackTrans()
	{
		base.gameObject.SetActive(value: false);
		if (_parent != null)
		{
			base.transform.SetParent(_parent);
		}
		base.transform.SetAsFirstSibling();
		base.transform.localPosition = Vector3.zero;
	}
}
