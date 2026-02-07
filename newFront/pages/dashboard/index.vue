<template>
  <div class="p-8">
    <h1 class="text-3xl font-bold mb-4">Dashboard</h1>
    <p>
      Welcome to your dashboard! Here you can manage your settings and view your
      activity.
    </p>
    <div class="mt-6">
      <h2 class="text-2xl font-semibold mb-2">Recent Activity</h2>
      <ul class="list-disc list-inside">
        <li>Logged in from IP</li>
        <li>Updated profile information</li>
        <li>Changed password</li>
      </ul>
    </div>
  </div>
</template>

<script setup>
definePageMeta({
  layout: "dashboard",
});
useSeoMeta({
  title: "Dashboard",
  description: "Dashboard overview page!",
});
</script>
