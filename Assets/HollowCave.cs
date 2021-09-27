using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollowCave : MonoBehaviour
{
	public Vector3    dimensions;
	public GameObject cubePrefab;
	public double     threshold;
	public float      scale;

	// Start is called before the first frame update
	void Start()
	{
		for (int x = 0; x < dimensions.x; x++)
		{
			for (int y = 0; y < dimensions.y; y++)
			{
				for (int z = 0; z < dimensions.z; z++)
				{
					// Any side exposed? Yes? Spawn the cube, otherwise hollow
					if (!CheckForTile(x - 1, y, z) || !CheckForTile(x + 1, y, z) || !CheckForTile(x, y + 1, z) || !CheckForTile(x, y - 1, z) || !CheckForTile(x, y, z + 1) || !CheckForTile(x, y, z - 1))
					{
						if (CheckForTile(x, y, z))
						{
							Instantiate(cubePrefab, new Vector3(x, y, z), Quaternion.identity);
						}
					}
				}
			}
		}
	}

	bool CheckForTile(int x, int y, int z)
	{
		return NoiseS3D.Noise(x * scale, y * scale, z * scale) > threshold;
	}

	// Update is called once per frame
	void Update()
	{
	}
}