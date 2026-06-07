using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace Simulator.GameWorld
{
	public class ShoppingBag : MonoBehaviour
	{
		private static int _openID;

		[SerializeField]
		private ParentConstraint m_constraint;

		[SerializeField]
		private Transform m_productsAnchor;

		[SerializeField]
		private Animator m_animator;

		private List<Product> m_list = new List<Product>();

		public static int OpenID
		{
			get
			{
				if (_openID == 0)
				{
					_openID = Animator.StringToHash("Open");
				}
				return _openID;
			}
		}

		public int ContentCount => m_list.Count;

		public void Show()
		{
			base.gameObject.SetActive(value: true);
		}

		public void AddProduct(Product product)
		{
			m_list.Add(product);
			product.Store(m_productsAnchor);
		}

		public IEnumerable<Product> Empty()
		{
			for (int i = ContentCount - 1; i >= 0; i--)
			{
				yield return m_list[i];
				m_list.RemoveAt(i);
			}
		}

		public void RemoveAddedConstraints()
		{
			m_constraint.SetSources(new List<ConstraintSource>
			{
				new ConstraintSource
				{
					sourceTransform = m_constraint.GetSource(0).sourceTransform,
					weight = 1f
				}
			});
		}

		public void AddConstraint(Transform anchor)
		{
			m_constraint.SetSource(0, new ConstraintSource
			{
				sourceTransform = m_constraint.GetSource(0).sourceTransform,
				weight = 0f
			});
			m_constraint.AddSource(new ConstraintSource
			{
				sourceTransform = anchor,
				weight = 1f
			});
		}

		public void Open(bool open)
		{
			m_animator.SetBool(OpenID, open);
		}

		public IEnumerable<Product> GetContent()
		{
			foreach (Product item in m_list)
			{
				yield return item;
			}
		}

		public float GetContentValue()
		{
			float num = 0f;
			foreach (Product item in m_list)
			{
				num += item.Price;
			}
			return num;
		}

		public bool Contains(int productUID)
		{
			foreach (Product item in m_list)
			{
				if (item.ProductData.UID == productUID)
				{
					return true;
				}
			}
			return false;
		}
	}
}
