<template>
  <div class="max-w-7xl mx-auto">
    <div v-if="pending" class="flex justify-center items-center min-h-[400px]">
      <div
        class="animate-spin rounded-full h-12 w-12 border-b-2 border-blue-600"
      ></div>
    </div>

    <div
      v-else-if="product"
      class="bg-white rounded-lg shadow-md overflow-hidden"
    >
      <div class="bg-gradient-to-r from-blue-600 to-blue-700 text-white p-6">
        <div class="flex items-center justify-between">
          <div>
            <h1 class="text-3xl font-bold mb-2">{{ product.title }}</h1>
            <p class="text-blue-100">
              {{ product.brand }} - {{ product.category }}
            </p>
          </div>
          <NuxtLink
            to="/dashboard/products"
            class="px-4 py-2 bg-white/20 hover:bg-white/30 rounded-lg transition"
          >
            العودة
          </NuxtLink>
        </div>
      </div>

      <div class="grid grid-cols-1 md:grid-cols-2 gap-8 p-6">
        <div>
          <div class="bg-gray-100 rounded-lg overflow-hidden mb-4">
            <img :src="mainImg" class="w-full h-96 object-contain" />
          </div>
        </div>

        <div class="space-y-6">
          <div class="flex items-center justify-between">
            <div>
              <div class="flex items-baseline gap-3">
                <span class="text-4xl font-bold text-gray-900"
                  >${{
                    (
                      product.price -
                      (product.discountPercentage.toFixed(2) / 100) *
                        product.price
                    ).toFixed(2)
                  }}</span
                >
                <span
                  v-if="product.discountPercentage"
                  class="text-xl text-gray-500 line-through"
                  >${{ product.price }}</span
                >
              </div>
              <div
                v-if="product.discountPercentage"
                class="inline-block mt-2 px-3 py-1 bg-red-100 text-red-700 rounded-full text-sm font-semibold"
              >
                خصم {{ product.discountPercentage.toFixed(0) }}%
              </div>
            </div>

            <div class="text-left">
              <div class="flex items-center gap-1 mb-1">
                <span class="text-2xl font-bold text-yellow-500">{{
                  product.rating
                }}</span>
                <svg
                  class="w-6 h-6 text-yellow-500"
                  fill="currentColor"
                  viewBox="0 0 20 20"
                >
                  <path
                    d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z"
                  />
                </svg>
              </div>
              <p class="text-sm text-gray-500">
                {{ product.reviews?.length || 0 }} تقييم
              </p>
            </div>
          </div>

          <div>
            <h3 class="text-lg font-semibold text-gray-900 mb-2">الوصف</h3>
            <p class="text-gray-600 leading-relaxed">
              {{ product.description }}
            </p>
          </div>

          <div class="grid grid-cols-2 gap-4">
            <div class="bg-gray-50 rounded-lg p-4">
              <h4 class="text-sm font-medium text-gray-500 mb-1">المخزون</h4>
              <p
                class="text-2xl font-bold"
                :class="product.stock > 10 ? 'text-green-600' : 'text-red-600'"
              >
                {{ product.stock }}
              </p>
            </div>

            <div class="bg-gray-50 rounded-lg p-4">
              <h4 class="text-sm font-medium text-gray-500 mb-1">الضمان</h4>
              <p class="text-lg font-semibold text-gray-900">
                {{ product.warrantyInformation }}
              </p>
            </div>
          </div>

          <div class="border border-gray-200 rounded-lg p-4">
            <div class="flex items-center gap-3 mb-2">
              <svg
                class="w-5 h-5 text-blue-600"
                fill="none"
                stroke="currentColor"
                viewBox="0 0 24 24"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M13 16V6a1 1 0 00-1-1H4a1 1 0 00-1 1v10a1 1 0 001 1h1m8-1a1 1 0 01-1 1H9m4-1V8a1 1 0 011-1h2.586a1 1 0 01.707.293l3.414 3.414a1 1 0 01.293.707V16a1 1 0 01-1 1h-1m-6-1a1 1 0 001 1h1M5 17a2 2 0 104 0m-4 0a2 2 0 114 0m6 0a2 2 0 104 0m-4 0a2 2 0 114 0"
                />
              </svg>
              <h4 class="font-semibold text-gray-900">معلومات الشحن</h4>
            </div>
            <p class="text-gray-600 text-sm">
              {{ product.shippingInformation }}
            </p>
            <p class="text-sm text-gray-500 mt-1">
              سياسة الإرجاع: {{ product.returnPolicy }}
            </p>
          </div>

          <div class="grid grid-cols-2 gap-4 pt-4 border-t border-gray-200">
            <div>
              <p class="text-sm text-gray-500">الحد الأدنى للطلب</p>
              <p class="font-semibold text-gray-900">
                {{ product.minimumOrderQuantity }} وحدة
              </p>
            </div>
            <div>
              <p class="text-sm text-gray-500">الرمز</p>
              <p class="font-semibold text-gray-900">{{ product.sku }}</p>
            </div>
          </div>

          <div class="flex gap-3 pt-4">
            <button
              class="flex-1 bg-blue-600 hover:bg-blue-700 text-white py-3 rounded-lg font-semibold transition"
            >
              تعديل المنتج
            </button>
            <button
              class="px-6 bg-red-600 hover:bg-red-700 text-white py-3 rounded-lg font-semibold transition"
            >
              حذف
            </button>
          </div>
        </div>
      </div>

      <div
        v-if="product.reviews && product.reviews.length > 0"
        class="border-t border-gray-200 p-6"
      >
        <h3 class="text-xl font-bold text-gray-900 mb-4">
          التقييمات ({{ product.reviews.length }})
        </h3>
        <div class="grid gap-4">
          <div
            v-for="(review, index) in product.reviews"
            :key="index"
            class="bg-gray-50 rounded-lg p-4"
          >
            <div class="flex items-center justify-between mb-2">
              <div class="flex items-center gap-2">
                <div
                  class="w-10 h-10 bg-blue-600 rounded-full flex items-center justify-center text-white font-semibold"
                >
                  {{ review.reviewerName.charAt(0) }}
                </div>
                <div>
                  <p class="font-semibold text-gray-900">
                    {{ review.reviewerName }}
                  </p>
                  <p class="text-xs text-gray-500">
                    {{ review.reviewerEmail }}
                  </p>
                </div>
              </div>
              <div class="flex items-center gap-1">
                <span class="font-bold text-yellow-500">{{
                  review.rating
                }}</span>
                <svg
                  class="w-5 h-5 text-yellow-500"
                  fill="currentColor"
                  viewBox="0 0 20 20"
                >
                  <path
                    d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z"
                  />
                </svg>
              </div>
            </div>
            <p class="text-gray-600 text-sm">{{ review.comment }}</p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
definePageMeta({
  layout: "dashboard",
});

const route = useRoute();
const productId = route.params.id;

const {
  data: product,
  pending,
  error,
  status,
} = await useFetch(`https://dummyjson.com/products/${productId}`);

if (error.value) {
  console.log("Error Status:", error.value.statusCode);
  console.log("Error Message:", error.value.message);
  throw createError({
    statusCode: error.value.statusCode,
    message: error.value.message,
  });
}
useSeoMeta({
  title: "Dashboard - view product - " + product.value.title,
  description: "view product page!",
});

const mainImg = product.value?.images?.[0] || "";
</script>
