using UnityEngine;

public class ExplodeSprite : MonoBehaviour
{
	[SerializeField]
	private Sprite sprite;

	[SerializeField]
	private int subdivisions;

	public void SetSprite(Sprite s)
	{
		sprite = s;
	}

	public void SetSubdivisions(int sub)
	{
		subdivisions = sub;
	}

	public void Explode()
	{
		if (sprite == null)
		{
			sprite = GetComponent<SpriteRenderer>().sprite;
		}
		Texture2D texture = sprite.texture;
		int num = texture.width / (subdivisions + 1);
		int num2 = texture.height / (subdivisions + 1);
		for (int i = 0; i < texture.height - num2; i += num2)
		{
			for (int j = 0; j < texture.width - num; j += num)
			{
				Texture2D texturePart = GetTexturePart(texture, j, i, num, num2);
				if (texturePart != null)
				{
					AddExplodingPart(texturePart);
				}
			}
		}
	}

	private Texture2D GetTexturePart(Texture2D tex, int x, int y, int w, int h)
	{
		Color[] pixels = tex.GetPixels(x, y, w, h);
		bool flag = true;
		Color[] array = pixels;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].a != 0f)
			{
				flag = false;
				break;
			}
		}
		if (flag)
		{
			return null;
		}
		Texture2D texture2D = new Texture2D(w, h);
		texture2D.SetPixels(0, 0, w, h, pixels);
		texture2D.Apply();
		return texture2D.CropToColoredPixels();
	}

	private void AddExplodingPart(Texture2D tex)
	{
		GameObject obj = Object.Instantiate(EnemyManager.Instance.ExplodedPartPrefab, base.transform.position + (Vector3)Random.insideUnitCircle * 0.1f, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
		SpriteRenderer component = obj.GetComponent<SpriteRenderer>();
		component.sprite = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), Vector2.one * 0.5f);
		component.sprite.texture.filterMode = FilterMode.Point;
		float num = Random.Range(0.1f, 2f);
		Vector2 vector = (obj.transform.position - base.transform.position).normalized;
		Vector2 vector2 = new Vector2(Train.Instance.TrainSpeedNormalized, 0f);
		obj.GetComponent<Rigidbody2D>().AddForce(vector * num + vector2, ForceMode2D.Impulse);
	}

	public bool IsSet()
	{
		if (sprite == null)
		{
			return false;
		}
		return true;
	}
}
