using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Script.Level2
{
    public class DoorTrigger : MonoBehaviour
    {
        public bool playerNearDoor = false;
        public GameObject UIWinScreen;

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (KeyOpen.hasKey && collision.CompareTag("Player"))
                playerNearDoor = true;
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
                playerNearDoor = false;
        }

        void Update()
        {
            if (playerNearDoor && Keyboard.current.eKey.wasPressedThisFrame)
            {
                UIWinScreen.SetActive(true);
            }
        }
    }
}