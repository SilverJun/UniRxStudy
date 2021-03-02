using UnityEngine;

namespace ViewContext
{
    public class ModelHolder
    {
    
    }
    
    public class BaseViewContext : MonoBehaviour
    {
        public ModelHolder Holder { get; protected set; }
    }
}