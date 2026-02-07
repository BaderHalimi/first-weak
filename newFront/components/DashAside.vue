<template>
  <aside class="fixed inset-y-0 right-0 w-64 bg-gray-900 text-white">
    <div class="flex flex-col h-full">
      <!-- Logo -->
      <div
        class="flex items-center justify-center h-16 bg-gray-800 border-b border-gray-700"
      >
        <h1 class="text-xl font-bold">لوحة التحكم</h1>
      </div>

      <!-- Navigation -->
      <nav class="flex-1 overflow-y-auto p-4">
        <ul class="space-y-2">
          <li
            v-for="item in navItems"
            :key="item.path"
            class="flex items-center"
          >
            <NuxtLink
              :to="item.path"
              class="flex items-center justify-end w-full px-4 py-3 rounded-lg hover:bg-gray-800 transition"
            >
              <span>{{ item.name }}</span>
            </NuxtLink>
          </li>
        </ul>
      </nav>

      <!-- User Profile -->
      <div class="p-4 border-t border-gray-700">
        <div
          class="flex items-center gap-3 px-4 py-3 rounded-lg hover:bg-gray-800 transition cursor-pointer"
        >
          <div
            class="w-10 h-10 bg-blue-600 rounded-full flex items-center justify-center"
          >
            <span class="text-sm font-semibold">AB</span>
          </div>
          <div class="flex-1">
            <p class="text-sm font-medium">أحمد محمد</p>
            <p class="text-xs text-gray-400">مدير النظام</p>
          </div>
        </div>
      </div>
    </div>
  </aside>
</template>

<script setup>
defineProps({
  navItems: {
    type: Array,
    required: true,
  },
});
</script>
