<template>
  <div class="p-8">
    <h1 class="text-3xl font-bold mb-4">Products</h1>
    <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
      <NuxtLink
        v-for="product in products?.products"
        :key="product.id"
        :to="`/dashboard/products/${product.id}`"
        class="bg-white p-4 rounded-lg shadow block hover:shadow-lg transition-shadow"
      >
        <h2 class="text-xl font-semibold mb-2">{{ product.title }}</h2>
        <p class="text-gray-600 mb-4">{{ product.description }}</p>
        <p class="text-lg font-bold text-blue-600">$ {{ product.price }}</p>
      </NuxtLink>
    </div>
  </div>
</template>

<script setup lang="ts">
useSeoMeta({
  title: "Dashboard - products",
  description: "products browse page!",
});
interface Product {
  id: number;
  title: string;
  description: string;
  price: number;
}

interface ProductsResponse {
  products: Product[];
}

const { data: products } = await useFetch<ProductsResponse>(
  "https://dummyjson.com/products",
);
definePageMeta({
  layout: "dashboard",
});
</script>
