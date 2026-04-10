using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Script.Level2
{
    public class KeyOpen : MonoBehaviour
    {
        public GameObject door;
        public static bool hasKey = false;
        

        // Sur la clé : ramassage
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                door.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
                hasKey = true;
                Destroy(gameObject);
            }
        }
    }
}