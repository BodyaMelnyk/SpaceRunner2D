using UnityEngine;

public class EnemyRotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y, _speed * 360 * Time.deltaTime);
    }
}
