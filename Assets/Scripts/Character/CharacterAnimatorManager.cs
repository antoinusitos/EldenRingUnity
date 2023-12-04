using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    public class CharacterAnimatorManager : MonoBehaviour
    {
        private CharacterManager character = null;

        private float vertical = 0f;
        private float horizontal = 0f;

        protected virtual void Awake()
        {
            character = GetComponent<CharacterManager>();
        }

        public void UpdateAnimatorValuesParamaters(float horizontalValue, float verticalValues)
        {
            character.animator.SetFloat("Horizontal", horizontalValue, 0.1f, Time.deltaTime);
            character.animator.SetFloat("Vertical", verticalValues, 0.1f, Time.deltaTime);
        }
    }
}